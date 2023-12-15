using Domain.Models.Questions;
using Domain.Models.Surveys;

namespace BLL.Services;

public interface ISurveyService
{
    // CRUD
    Task<Survey> CreateSurveyAsync(Survey survey);
    
    Task<Survey> GetSurveyAsync(int surveyId);
    
    Task UpdateSurveyAsync(Survey survey);
    
    Task DeleteSurveyAsync(int surveyId);
    
    // Business logic
    Task<IEnumerable<Survey>> GetAllSurveysAsync();

    Task<IEnumerable<Survey>> GetUserSurveysAsync(int userId);

    Task AssignSurveyToUserAsync(int userId, int surveyId);

    Task<IEnumerable<BaseQuestion>> GetSurveyQuestionsAsync(int surveyId);
    
    Task<SurveyAttempt> GetSurveyAttemptIncludeAnswersAsync(int surveyAttemptId);

    Task<SurveyAttempt> SaveSurveyAttemptAsync(SurveyAttempt surveyAttempt);
}