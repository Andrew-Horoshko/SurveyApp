using Domain;
using Domain.Models.Questions;
using Domain.Models.Surveys;

namespace BLL.Services;

// TODO: Add custom exceptions?
public class SurveyService : ISurveyService
{
    private readonly ISurveyRepository _surveyRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBaseRepository<SurveyAttempt> _surveyAttemptRepository;

    public SurveyService(
        ISurveyRepository surveyRepository, 
        IUserRepository userRepository,
        IBaseRepository<SurveyAttempt> surveyAttemptRepository)
    {
        _surveyRepository = surveyRepository;
        _userRepository = userRepository;
        _surveyAttemptRepository = surveyAttemptRepository;
    }

    public async Task<Survey> GetSurvey(int surveyId)
    {
        var survey = await _surveyRepository.GetByIdAsync(surveyId);

        if (survey == null)
        {
            throw new Exception($"Survey with id {surveyId} is not found: 404");
        }

        return survey;
    }

    public async Task<IEnumerable<Survey>> GetAllSurveys()
    {
        return await _surveyRepository.GetAll();
    }

    public async Task<IEnumerable<Survey>> GetUserSurveys(int userId)
    {
        var user = await _userRepository.GetByIdIncludeSurveys(userId);

        if (user == null)
        {
            throw new Exception($"User with id {userId} is not found: 404");
        }

        return user.AccessibleSurveys;
    }

    public async Task AssignSurveyToUser(int userId, int surveyId)
    {
        var user = await _userRepository.GetByIdIncludeSurveys(userId);
        var survey = await _surveyRepository.GetByIdAsync(surveyId);

        if (user == null)
        {
            throw new Exception($"User with id {userId} is not found: 404");
        }
        if (survey == null)
        {
            throw new Exception($"Survey with id {surveyId} is not found: 404");
        }

        user.AccessibleSurveys.Add(survey);
        await _userRepository.UpdateAsync(user);
    }

    public async Task<IEnumerable<QuestionBase>> GetSurveyQuestions(int surveyId)
    {
        var survey = await _surveyRepository.GetByIdIncludeQuestions(surveyId);

        if (survey == null)
        {
            throw new Exception($"Survey with id {surveyId} is not found: 404");
        }

        return survey.Questions;
    }

    public async Task<SurveyAttempt> GetSurveyAttempt(int surveyAttemptId)
    {
        var surveyAttempt = await _surveyAttemptRepository.GetByIdAsync(surveyAttemptId);
        
        if (surveyAttempt == null)
        {
            throw new Exception($"Survey attempt with id {surveyAttemptId} is not found: 404");
        }

        return surveyAttempt;
    }

    public async Task<SurveyAttempt> SaveSurveyAttempt(SurveyAttempt surveyAttempt)
    {
        return await _surveyAttemptRepository.CreateAsync(surveyAttempt);
    }
}