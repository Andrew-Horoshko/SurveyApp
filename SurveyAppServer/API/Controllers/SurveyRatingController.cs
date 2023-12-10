using DAL;
using Domain.Models.Surveys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SurveyAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly SurveyAppDbContext _context;

        public RatingsController(SurveyAppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Submit")]
        public async Task<ActionResult<SurveyRating>> SubmitRating(SurveyRating surveyRating)
        {
            var existingRating = await _context.SurveyRatings
                .FirstOrDefaultAsync(sr => sr.SurveyId == surveyRating.SurveyId && sr.UserId == surveyRating.UserId);

            if (existingRating != null)
            {
                existingRating.Mark = surveyRating.Mark;
                _context.Entry(existingRating).State = EntityState.Modified;
            }
            else
            {
                _context.SurveyRatings.Add(surveyRating);
            }

            await _context.SaveChangesAsync();

            UpdateAverageRating(surveyRating.SurveyId);

            string getSurveyRatingName = nameof(GetSurveyRating);
            return CreatedAtAction(getSurveyRatingName, new { id = surveyRating.SurveyRatingId }, surveyRating);
        }

        private async Task<ActionResult<SurveyRating>> GetSurveyRating(int id)
        {
            var surveyRating = await _context.SurveyRatings.FindAsync(id);

            if (surveyRating == null)
            {
                return NotFound();
            }

            return surveyRating;
        }

        [HttpGet("AllRatings")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllRatings()
        {
            var ratings = await _context.SurveyRatings
                .Include(r => r.Survey)
                .Include(r => r.User)
                .Select(r => new
                {
                    SurveyName = r.Survey.Title,
                    UserName = r.User.Username,
                    r.Mark
                })
                .ToListAsync();

            return ratings;
        }

        private void UpdateAverageRating(int surveyId)
        {
            var ratings = _context.SurveyRatings.Where(r => r.SurveyId == surveyId).ToList();
            if (ratings.Any())
            {
                var averageRating = ratings.Average(r => (int) r.Mark);
                var survey = _context.Surveys.Find(surveyId);
                if (survey != null)
                {
                    survey.AverageRating = averageRating;
                    _context.Entry(survey).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }
    }
}
