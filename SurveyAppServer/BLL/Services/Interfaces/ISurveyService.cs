using Domain.Models.Questions;
using Domain.Models.Surveys;

namespace BLL.Services;

public interface ISurveyService
{
    Task<Survey> GetSurvey(int surveyId);
    
    Task<IEnumerable<Survey>> GetAllSurveys();

    Task<IEnumerable<Survey>> GetUserSurveys(int userId);

    Task AssignSurveyToUser(int userId, int surveyId);

    Task<IEnumerable<QuestionBase>> GetSurveyQuestions(int surveyId);
    
    Task<SurveyAttempt> GetSurveyAttempt(int surveyAttemptId);

    Task<SurveyAttempt> SaveSurveyAttempt(SurveyAttempt surveyAttempt);
}