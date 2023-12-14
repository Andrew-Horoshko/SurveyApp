using Domain.Models.Surveys;

namespace Domain;

public interface ISurveyAttemptRepository : IBaseRepository<SurveyAttempt>
{
    Task<SurveyAttempt?> GetByIdIncludeAnswersAsync(int surveyAttemptId);
}