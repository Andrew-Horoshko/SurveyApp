using Domain.Models.Surveys;

namespace Domain;

public interface ISurveyRatingRepository : IBaseRepository<SurveyRating>
{
    Task<IEnumerable<SurveyRating>> GetBySurveyIdAsync(int surveyId);
}