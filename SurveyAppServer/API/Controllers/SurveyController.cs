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
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurvey(int surveyId)
        {
            var survey = await _surveyService.GetSurvey(surveyId);

            return Ok(survey);
        }

        [HttpGet("AllSurveys")]
        public async Task<ActionResult<IEnumerable<Survey>>> GetAllSurveys()
        {
            var surveys = await _surveyService.GetAllSurveys();

            return Ok(surveys);
        }

        [HttpPost("AssignToUser")]
        public async Task<IActionResult> AssignSurveyToUser(int userId, int surveyId)
        {
            await _surveyService.AssignSurveyToUser(userId, surveyId);

            return NoContent();
        }

        [HttpGet("UserSurveys/{userId}")]
        public async Task<ActionResult<IEnumerable<Survey>>> GetUserSurveys(int userId)
        {
            var userSurveys = await  _surveyService.GetUserSurveys(userId);

            return Ok(userSurveys);
        }

        [HttpGet("Questions/{surveyId}")]
        public async Task<ActionResult<IEnumerable<QuestionBase>>> GetSurveyQuestions(int surveyId)
        {
            var surveyQuestions = await _surveyService.GetSurveyQuestions(surveyId);

            return Ok(surveyQuestions);
        }

        [HttpPost("SaveAttempt")]
        public async Task<ActionResult<SurveyAttempt>> SaveSurveyAttempt(SurveyAttempt surveyAttempt)
        {
            surveyAttempt = await _surveyService.SaveSurveyAttempt(surveyAttempt);

            string getSurveyAttemptName = nameof(GetSurveyAttempt);
            return CreatedAtAction(getSurveyAttemptName, new { id = surveyAttempt.SurveyAttemptId }, surveyAttempt);
        }

        private async Task<ActionResult<SurveyAttempt>> GetSurveyAttempt(int surveyAttemptId)
        {
            var surveyAttempt = await _surveyService.GetSurveyAttempt(surveyAttemptId);

            return Ok(surveyAttempt);
        }
    }
}
