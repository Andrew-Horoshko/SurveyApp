using BLL.Exceptions;
using BLL.Services.Interfaces;
using Domain;
using Domain.Models.Answers;

namespace BLL.Services;

public class AnswerService : IAnswerService
{
    private const string Target = "Answer";
    private readonly IBaseRepository<Answer> _answerRepository;

    public AnswerService(IBaseRepository<Answer> answerRepository)
    {
        _answerRepository = answerRepository;
    }

    public async Task<Answer> GetAnswerAsync(int answerId)
    {
        var answer = await _answerRepository.GetByIdAsync(answerId);

        if (answer == null)
        {
            throw new EntityNotFoundException(Target, answerId);
        }

        return answer;
    }

    public async Task<Answer> CreateAnswerAsync(Answer answer)
    {
        return await _answerRepository.CreateAsync(answer);
    }

    public async Task UpdateAnswerAsync(Answer answer)
    {
        await _answerRepository.UpdateAsync(answer);
    }

    public async Task DeleteAnswerAsync(int answerId)
    {
        await _answerRepository.DeleteAsync(answerId);
    }
}