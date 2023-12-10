using Domain.Models.Surveys;

namespace Domain;

public interface ISurveyRepository : IBaseRepository<Survey>
{
    Task<Survey?> GetByIdIncludeQuestionsAsync(int surveyId);
}