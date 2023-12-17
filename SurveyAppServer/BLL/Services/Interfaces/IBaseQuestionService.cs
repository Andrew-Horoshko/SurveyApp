using Domain.Models.Answers;
using Domain.Models.Questions;

namespace BLL.Services.Interfaces;

public interface IBaseQuestionService
{
    // CRUD
    public Task<BaseQuestion> GetQuestionAsync(int questionId);

    public Task<BaseQuestion> CreateQuestionAsync(BaseQuestion baseQuestion);

    public Task UpdateQuestionAsync(BaseQuestion baseQuestion);

    public Task DeleteQuestionAsync(int questionId);
    
    // Business logic
    public Task<IEnumerable<Answer>> GetQuestionAnswersAsync(int questionId);

    public Task<string> GetQuestionDescriptionAsync(int questionId);
}