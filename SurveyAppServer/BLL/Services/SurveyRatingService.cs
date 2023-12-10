using BLL.Exceptions;
using BLL.Services.Interfaces;
using Domain;
using Domain.Models.Surveys;

namespace BLL.Services;

public class SurveyRatingService : ISurveyRatingService
{
    private const string SurveyTarget = "Survey";
    private const string SurveyRatingTarget = "SurveyRating";
    
    private readonly ISurveyRatingRepository _surveyRatingRepository;
    private readonly ISurveyRepository _surveyRepository;

    public SurveyRatingService(ISurveyRatingRepository surveyRatingRepository, ISurveyRepository surveyRepository)
    {
        _surveyRatingRepository = surveyRatingRepository;
        _surveyRepository = surveyRepository;
    }
    
    private async Task UpdateAverageRating(int surveyId)
    {
        var surveyRatings = await _surveyRatingRepository.GetBySurveyIdAsync(surveyId);
        var enumerable = surveyRatings.ToList();
        if (!enumerable.Any())
        {
            return;
        }
        var survey = await _surveyRepository.GetByIdAsync(surveyId);
        if (survey == null)
        {
            throw new EntityNotFoundException(SurveyTarget, surveyId);
        }

        var averageRating = enumerable.Average(r => (int) r.Mark);
        survey.AverageRating = averageRating;
        await _surveyRepository.UpdateAsync(survey);
    }
    
    // CRUD
    public async Task<SurveyRating> CreateSurveyRatingAsync(SurveyRating surveyRating)
    {
        surveyRating = await _surveyRatingRepository.CreateAsync(surveyRating);
        
        await UpdateAverageRating(surveyRating.SurveyId);

        return surveyRating;
    }
    
    public async Task<SurveyRating> GetSurveyRatingAsync(int surveyRatingId)
    {
        var surveyRating = await _surveyRatingRepository.GetByIdAsync(surveyRatingId);

        if (surveyRating == null)
        {
            throw new EntityNotFoundException(SurveyRatingTarget, surveyRatingId);
        }

        return surveyRating;
    }

    public async Task UpdateSurveyRatingAsync(SurveyRating surveyRating)
    {
        await _surveyRatingRepository.UpdateAsync(surveyRating);
        
        await UpdateAverageRating(surveyRating.SurveyId);
    }

    public async Task DeleteSurveyRatingAsync(int surveyRatingId)
    {
        var surveyRating = await _surveyRatingRepository.GetByIdAsync(surveyRatingId);
        
        if (surveyRating == null)
        {
            throw new EntityNotFoundException(SurveyRatingTarget, surveyRatingId);
        }
        
        await _surveyRatingRepository.DeleteAsync(surveyRatingId);

        await UpdateAverageRating(surveyRating.SurveyId);
    }

    // Business logic
    public Task<IEnumerable<SurveyRating>> GetAllSurveyRatingsAsync()
    {
        return _surveyRatingRepository.GetAll();
    }
}