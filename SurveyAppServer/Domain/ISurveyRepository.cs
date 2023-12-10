using Domain.Models.Surveys;

namespace Domain;

public interface ISurveyRepository : IBaseRepository<Survey>
{
    Task<Survey?> GetByIdIncludeQuestions(int surveyId);
}