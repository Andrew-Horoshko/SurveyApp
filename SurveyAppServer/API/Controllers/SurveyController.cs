using BLL.Services;
using Domain.Models.Questions;
using Domain.Models.Surveys;
using SurveyAppServer.ViewModels;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SurveyAppServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveyController : ControllerBase
{
    private readonly ISurveyService _surveyService;
    private readonly IMapper _mapper;

    public SurveyController(ISurveyService surveyService, IMapper mapper)
    {
        _surveyService = surveyService;
        _mapper = mapper;
    }
        
    // CRUD
    [HttpGet]
    public async Task<ActionResult<SurveyViewModel>> GetSurvey(int surveyId)
    {
        var survey = await _surveyService.GetSurveyAsync(surveyId);

        var surveyViewModel = _mapper.Map<SurveyViewModel>(survey);
            
        return Ok(surveyViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<SurveyViewModel>> CreateSurvey(Survey survey)
    {
        survey = await _surveyService.CreateSurveyAsync(survey);
            
        var surveyViewModel = _mapper.Map<SurveyViewModel>(survey);
            
        return Ok(surveyViewModel);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateSurvey(SurveyViewModel surveyViewModel)
    {
        var survey = _mapper.Map<Survey>(surveyViewModel);
            
        await _surveyService.UpdateSurveyAsync(survey);

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteSurvey(int surveyId)
    {
        await _surveyService.DeleteSurveyAsync(surveyId);

        return NoContent();
    }
        
    // Business logic
    [HttpGet("AllSurveys")]
    public async Task<ActionResult<IEnumerable<SurveyViewModel>>> GetAllSurveys()
    {
        var surveys = await _surveyService.GetAllSurveysAsync();

        var surveyViewModels = surveys.Select(s => _mapper.Map<SurveyViewModel>(s));

        return Ok(surveyViewModels);
    }

    [HttpPost("AssignToUser")]
    public async Task<IActionResult> AssignSurveyToUser(int userId, int surveyId)
    {
        await _surveyService.AssignSurveyToUserAsync(userId, surveyId);

        return NoContent();
    }

    [HttpGet("UserSurveys/{userId}")]
    public async Task<ActionResult<IEnumerable<SurveyViewModel>>> GetUserSurveys(int userId)
    {
        var userSurveys = await  _surveyService.GetUserSurveysAsync(userId);

        var userSurveyViewModels = userSurveys
            .Select(s => _mapper.Map<SurveyViewModel>(s));
            
        return Ok(userSurveyViewModels);
    }

    [HttpGet("Questions/{surveyId}")]
    public async Task<ActionResult<IEnumerable<BaseQuestion>>> GetSurveyQuestions(int surveyId)
    {
        var surveyQuestions = await _surveyService.GetSurveyQuestionsAsync(surveyId);

        return Ok(surveyQuestions);
    }

    [HttpPost("SaveAttempt")]
    public async Task<ActionResult<SurveyAttemptViewModel>> SaveSurveyAttempt(SurveyAttemptViewModel surveyAttemptViewModel)
    {
        var surveyAttempt = _mapper.Map<SurveyAttempt>(surveyAttemptViewModel);
            
        surveyAttempt = await _surveyService.SaveSurveyAttemptAsync(surveyAttempt);

        string getSurveyAttemptName = nameof(GetSurveyAttempt);
        return CreatedAtAction(getSurveyAttemptName, new { id = surveyAttempt.SurveyAttemptId }, surveyAttempt);
    }

    private async Task<ActionResult<SurveyAttemptViewModel>> GetSurveyAttempt(int surveyAttemptId)
    {
        var surveyAttempt = await _surveyService.GetSurveyAttemptAsync(surveyAttemptId);

        var surveyAttemptViewModel = _mapper.Map<SurveyAttemptViewModel>(surveyAttempt);

        return Ok(surveyAttemptViewModel);
    }
}