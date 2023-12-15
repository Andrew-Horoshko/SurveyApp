using BLL.Services.Interfaces;
using Domain.Models.Surveys;
using SurveyAppServer.ViewModels;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SurveyAppServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly ISurveyRatingService _surveyRatingService;
    private readonly IMapper _mapper;

    public RatingsController(ISurveyRatingService surveyRatingService, IMapper mapper)
    {
        _surveyRatingService = surveyRatingService;
        _mapper = mapper;
    }
        
    // CRUD
    [HttpGet]
    public async Task<ActionResult<SurveyRatingViewModel>> GetSurveyRating(int surveyRatingId)
    {
        var surveyRating = await _surveyRatingService.GetSurveyRatingAsync(surveyRatingId);

        var surveyRatingViewModel = _mapper.Map<SurveyRatingViewModel>(surveyRating);

        return Ok(surveyRatingViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<SurveyRatingViewModel>> CreateSurveyRating(SurveyRatingViewModel surveyRatingViewModel)
    {
        var surveyRating = _mapper.Map<SurveyRating>(surveyRatingViewModel);
        
        surveyRating = await _surveyRatingService.CreateSurveyRatingAsync(surveyRating);

        surveyRatingViewModel = _mapper.Map<SurveyRatingViewModel>(surveyRating);
        
        return Ok(surveyRatingViewModel);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateSurveyRating(SurveyRatingViewModel surveyRatingViewModel)
    {
        var surveyRating = _mapper.Map<SurveyRating>(surveyRatingViewModel);
        
        await _surveyRatingService.UpdateSurveyRatingAsync(surveyRating);

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteSurveyRating(int surveyRatingId)
    {
        await _surveyRatingService.DeleteSurveyRatingAsync(surveyRatingId);

        return NoContent();
    }

    [HttpGet("AllRatings")]
    public async Task<ActionResult<IEnumerable<SurveyRatingViewModel>>> GetAllRatings()
    {
        var surveyRatings = await _surveyRatingService.GetAllSurveyRatingsAsync();

        var surveyRatingViewModels = surveyRatings
            .Select(s => _mapper.Map<SurveyRatingViewModel>(s));
        
        return Ok(surveyRatingViewModels);
    }
}