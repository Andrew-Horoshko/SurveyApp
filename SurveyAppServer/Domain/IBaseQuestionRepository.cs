using Domain.Models.Questions;

namespace Domain;

public interface IBaseQuestionRepository : IBaseRepository<BaseQuestion>
{
    Task<BaseQuestion?> GetByIdIncludeAnswersAsync(int questionId);
}