using Domain.Models.Answers;

namespace BLL.Services.Interfaces;

public interface IAnswerService
{
    Task<Answer> GetAnswerAsync(int answerId);

    Task<Answer> CreateAnswerAsync(Answer answer);

    Task UpdateAnswerAsync(Answer answer);

    Task DeleteAnswerAsync(int answerId);
}