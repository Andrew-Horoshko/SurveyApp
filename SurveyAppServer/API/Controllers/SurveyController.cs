using BLL.Services;
using Domain.Models.Questions;
using Domain.Models.Surveys;

using Microsoft.AspNetCore.Mvc;

namespace SurveyAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        
        // CRUD
        [HttpGet]
        public async Task<ActionResult<Survey>> GetSurvey(int surveyId)
        {
            var survey = await _surveyService.GetSurveyAsync(surveyId);

            return Ok(survey);
        }

        [HttpPost]
        public async Task<ActionResult<Survey>> CreateSurvey(Survey survey)
        {
            survey = await _surveyService.CreateSurveyAsync(survey);

            return Ok(survey);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSurvey(Survey survey)
        {
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
        public async Task<ActionResult<IEnumerable<Survey>>> GetAllSurveys()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();

            return Ok(surveys);
        }

        [HttpPost("AssignToUser")]
        public async Task<IActionResult> AssignSurveyToUser(int userId, int surveyId)
        {
            await _surveyService.AssignSurveyToUserAsync(userId, surveyId);

            return NoContent();
        }

        [HttpGet("UserSurveys/{userId}")]
        public async Task<ActionResult<IEnumerable<Survey>>> GetUserSurveys(int userId)
        {
            var userSurveys = await  _surveyService.GetUserSurveysAsync(userId);

            return Ok(userSurveys);
        }

        [HttpGet("Questions/{surveyId}")]
        public async Task<ActionResult<IEnumerable<BaseQuestion>>> GetSurveyQuestions(int surveyId)
        {
            var surveyQuestions = await _surveyService.GetSurveyQuestionsAsync(surveyId);

            return Ok(surveyQuestions);
        }

        [HttpPost("SaveAttempt")]
        public async Task<ActionResult<SurveyAttempt>> SaveSurveyAttempt(SurveyAttempt surveyAttempt)
        {
            surveyAttempt = await _surveyService.SaveSurveyAttemptAsync(surveyAttempt);

            string getSurveyAttemptName = nameof(GetSurveyAttempt);
            return CreatedAtAction(getSurveyAttemptName, new { id = surveyAttempt.SurveyAttemptId }, surveyAttempt);
        }

        private async Task<ActionResult<SurveyAttempt>> GetSurveyAttempt(int surveyAttemptId)
        {
            var surveyAttempt = await _surveyService.GetSurveyAttemptAsync(surveyAttemptId);

            return Ok(surveyAttempt);
        }
    }
}
