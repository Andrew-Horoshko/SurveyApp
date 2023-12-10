using BLL.Exceptions;
using BLL.Services.Interfaces;
using Domain;
using Domain.Models.Answers;
using Domain.Models.Questions;

using Microsoft.Extensions.Logging;

namespace BLL.Services;

public class QuestionBaseService : IQuestionBaseService
{
    private const string QuestionTarget = "Question";

    private readonly IBaseQuestionRepository _baseQuestionRepository;
    private readonly ILogger _logger;

    public QuestionBaseService(
        IBaseQuestionRepository baseQuestionRepository,
        ILogger<QuestionBaseService> logger)
    {
        _baseQuestionRepository = baseQuestionRepository;
        _logger = logger;
    }

    private async Task<BaseQuestion?> GetBaseQuestion(int questionId)
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
        };
    }
    
    public async Task<IEnumerable<Answer>> GetQuestionAnswersAsync(int questionId)
    {
        var question = await GetBaseQuestion(questionId);
        
        _logger.LogInformation("Queried answers for:\n{q}", question);

        return question!.Answers;
    }

    public async Task<string> GetQuestionDescriptionAsync(int questionId)
    {
        var question = await GetBaseQuestion(questionId);

        return question!.GetDescription();
    }
}