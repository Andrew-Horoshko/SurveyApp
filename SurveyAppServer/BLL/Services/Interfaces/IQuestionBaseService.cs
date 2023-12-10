using Domain.Models.Answers;

namespace BLL.Services.Interfaces;

public interface IQuestionBaseService
{
    // CRUD is not here because it probably should be implemented for each entity separately
    // (ISingleChoiceQuestionService, IMultipleChoiceQuestionService, IOpenTextQuestionService)
    
    // Business logic
    public Task<IEnumerable<Answer>> GetQuestionAnswersAsync(int questionId);

    public Task<string> GetQuestionDescriptionAsync(int questionId);
}