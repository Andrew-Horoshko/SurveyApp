using BLL.Exceptions;
using Domain;
using Domain.Models.Questions;
using Domain.Models.Surveys;

namespace BLL.Services;

// TODO: Add custom exceptions?
public class SurveyService : ISurveyService
{
    private const string SurveyTarget = "Survey";
    private const string SurveyAttemptTarget = "SurveyAttempt";
    private const string UserTarget = "User";
    
    private readonly ISurveyRepository _surveyRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISurveyAttemptRepository _surveyAttemptRepository;

    public SurveyService(
        ISurveyRepository surveyRepository, 
        IUserRepository userRepository,
        ISurveyAttemptRepository surveyAttemptRepository)
    {
        _surveyRepository = surveyRepository;
        _userRepository = userRepository;
        _surveyAttemptRepository = surveyAttemptRepository;
    }

    // CRUD
    public async Task<Survey> CreateSurveyAsync(Survey survey)
    {
        return await _surveyRepository.CreateAsync(survey);
    }

    public async Task<Survey> GetSurveyAsync(int surveyId)
    {
        var survey = await _surveyRepository.GetByIdAsync(surveyId);

        if (survey == null)
        {
            throw new EntityNotFoundException(SurveyTarget, surveyId);
        }

        return survey;
    }

    public async Task UpdateSurveyAsync(Survey survey)
    {
        await _surveyRepository.UpdateAsync(survey);
    }

    public async Task DeleteSurveyAsync(int surveyId)
    {
        await _surveyRepository.DeleteAsync(surveyId);
    }
    
    // Business logic
    public async Task<IEnumerable<Survey>> GetAllSurveysAsync()
    {
        return await _surveyRepository.GetAll();
    }

    public async Task<IEnumerable<Survey>> GetUserSurveysAsync(int userId)
    {
        var user = await _userRepository.GetByIdIncludeSurveysAsync(userId);

        if (user == null)
        {
            throw new EntityNotFoundException(UserTarget, userId);
        }

        return user.AccessibleSurveys;
    }

    public async Task AssignSurveyToUserAsync(int userId, int surveyId)
    {
        var user = await _userRepository.GetByIdIncludeSurveysAsync(userId);
        var survey = await _surveyRepository.GetByIdAsync(surveyId);

        if (user == null)
        {
            throw new EntityNotFoundException(UserTarget, userId);
        }
        if (survey == null)
        {
            throw new EntityNotFoundException(SurveyTarget, surveyId);
        }

        user.AccessibleSurveys.Add(survey);
        await _userRepository.UpdateAsync(user);
    }

    public async Task<IEnumerable<BaseQuestion>> GetSurveyQuestionsAsync(int surveyId)
    {
        var survey = await _surveyRepository.GetByIdIncludeQuestionsAsync(surveyId);

        if (survey == null)
        {
            throw new EntityNotFoundException(SurveyTarget, surveyId);
        }

        return survey.Questions;
    }

    public async Task<SurveyAttempt> GetSurveyAttemptIncludeAnswersAsync(int surveyAttemptId)
    {
        var surveyAttempt = await _surveyAttemptRepository.GetByIdIncludeAnswersAsync(surveyAttemptId);
        
        if (surveyAttempt == null)
        {
            throw new EntityNotFoundException(SurveyAttemptTarget, surveyAttemptId);
        }

        return surveyAttempt;
    }

    public async Task<SurveyAttempt> SaveSurveyAttemptAsync(SurveyAttempt surveyAttempt)
    {
        return await _surveyAttemptRepository.CreateAsync(surveyAttempt);
    }
}