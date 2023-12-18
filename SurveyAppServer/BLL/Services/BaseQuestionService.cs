using BLL.Exceptions;
using BLL.Services.Interfaces;
using Domain;
using Domain.Models.Answers;
using Domain.Models.Questions;

using Microsoft.Extensions.Logging;

namespace BLL.Services;

public class BaseQuestionService : IBaseQuestionService
{
    private const string QuestionTarget = "Question";

    private readonly IBaseQuestionRepository _baseQuestionRepository;
    private readonly ILogger _logger;

    public BaseQuestionService(
        IBaseQuestionRepository baseQuestionRepository,
        ILogger<BaseQuestionService> logger)
    {
        _baseQuestionRepository = baseQuestionRepository;
        _logger = logger;
    }

    public async Task<BaseQuestion> GetQuestionAsync(int questionId)
    {
        var question = await _baseQuestionRepository.GetByIdIncludeAnswersAsync(questionId);

        if (question == null)
        {
            throw new EntityNotFoundException(QuestionTarget, questionId);
        }

        return question.QuestionType switch
        {
            QuestionType.SingleChoice => question as SingleChoiceQuestion,
            QuestionType.MultipleChoice => question as MultipleChoiceQuestion,
            QuestionType.OpenText => question as OpenTextQuestion,
            _ => question
        } ?? question;
    }

    public async Task<BaseQuestion> CreateQuestionAsync(BaseQuestion baseQuestion)
    {
        return await _baseQuestionRepository.CreateAsync(baseQuestion);
    }

    public async Task UpdateQuestionAsync(BaseQuestion baseQuestion)
    {
        await _baseQuestionRepository.UpdateAsync(baseQuestion);
    }

    public async Task DeleteQuestionAsync(int questionId)
    {
        await _baseQuestionRepository.DeleteAsync(questionId);
    }

    public async Task<IEnumerable<Answer>> GetQuestionAnswersAsync(int questionId)
    {
        var question = await GetQuestionAsync(questionId);
        
        _logger.LogInformation("Queried answers for:\n{q}", question);

        return question.Answers;
    }

    public async Task<string> GetQuestionDescriptionAsync(int questionId)
    {
        var question = await GetQuestionAsync(questionId);

        return question.GetDescription();
    }
}