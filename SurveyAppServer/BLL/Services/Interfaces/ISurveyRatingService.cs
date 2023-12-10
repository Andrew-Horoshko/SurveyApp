using Domain.Models.Surveys;

namespace BLL.Services.Interfaces;

public interface ISurveyRatingService
{
    // CRUD
    public Task<SurveyRating> CreateSurveyRatingAsync(SurveyRating surveyRating);
    
    public Task<SurveyRating> GetSurveyRatingAsync(int surveyRatingId);

    public Task UpdateSurveyRatingAsync(SurveyRating surveyRating);

    public Task DeleteSurveyRatingAsync(int surveyRatingId);
    
    // Business logic
    public Task<IEnumerable<SurveyRating>> GetAllSurveyRatingsAsync();
}