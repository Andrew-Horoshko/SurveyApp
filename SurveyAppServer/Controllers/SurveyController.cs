using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SurveyAppServer.Models.Questions;
using SurveyAppServer.Models.Surveys;

namespace SurveyAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly SurveyAppDbContext _context;

        public SurveyController(SurveyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllSurveys")]
        public async Task<ActionResult<IEnumerable<Survey>>> GetAllSurveys()
        {
            return await _context.Surveys.ToListAsync();
        }

        [HttpPost("AssignToUser")]
        public async Task<IActionResult> AssignSurveyToUser(int userId, int surveyId)
        {
            var user = await _context.Users.FindAsync(userId);
            var survey = await _context.Surveys.FindAsync(surveyId);

            if (user == null || survey == null)
            {
                return NotFound();
            }

            user.AccessibleSurveys.Add(survey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("UserSurveys/{userId}")]
        public async Task<ActionResult<IEnumerable<Survey>>> GetUserSurveys(int userId)
        {
            var userWithSurveys = await _context.Users
                .Include(u => u.AccessibleSurveys)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (userWithSurveys == null)
            {
                return NotFound();
            }

            return userWithSurveys.AccessibleSurveys.ToList();
        }

        [HttpGet("Questions/{surveyId}")]
        public async Task<ActionResult<IEnumerable<QuestionBase>>> GetSurveyQuestions(int surveyId)
        {
            var surveyWithQuestions = await _context.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => (q as SingleChoiceQuestion)!.Answer)
                .Include(s => s.Questions)
                .ThenInclude(q => (q as MultipleChoiceQuestion)!.Answers)
                .Include(s => s.Questions)
                .ThenInclude(q => (q as OpenTextQuestion)!.Text)
                .FirstOrDefaultAsync(s => s.SurveyId == surveyId);

            if (surveyWithQuestions == null)
            {
                return NotFound();
            }

            return surveyWithQuestions.Questions.ToList();
        }

        [HttpPost("SaveAttempt")]
        public async Task<ActionResult<SurveyAttempt>> SaveSurveyAttempt(SurveyAttempt surveyAttempt)
        {
            _context.SurveyAttempts.Add(surveyAttempt);
            await _context.SaveChangesAsync();

            string getSurveyAttemptName = nameof(GetSurveyAttempt);
            return CreatedAtAction(getSurveyAttemptName, new { id = surveyAttempt.SurveyAttemptId }, surveyAttempt);
        }

        private async Task<ActionResult<SurveyAttempt>> GetSurveyAttempt(int id)
        {
            var surveyAttempt = await _context.SurveyAttempts
                .Include(sa => sa.SurveyAnswers)
                .FirstOrDefaultAsync(sa => sa.SurveyAttemptId == id);

            if (surveyAttempt == null)
            {
                return NotFound();
            }

            return surveyAttempt;
        }
    }
}
