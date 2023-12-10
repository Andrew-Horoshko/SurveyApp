using BLL.Services.Interfaces;
using Domain.Models.Surveys;

using Microsoft.AspNetCore.Mvc;

namespace SurveyAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly ISurveyRatingService _surveyRatingService;

        public RatingsController(ISurveyRatingService surveyRatingService)
        {
            _surveyRatingService = surveyRatingService;
        }
        
        // CRUD
        [HttpGet]
        public async Task<ActionResult<SurveyRating>> GetSurveyRating(int surveyRatingId)
        {
            var surveyRating = await _surveyRatingService.GetSurveyRatingAsync(surveyRatingId);

            return Ok(surveyRating);
        }

        [HttpPost]
        public async Task<ActionResult<SurveyRating>> CreateSurveyRating(SurveyRating surveyRating)
        {
            surveyRating = await _surveyRatingService.CreateSurveyRatingAsync(surveyRating);

            return Ok(surveyRating);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSurveyRating(SurveyRating surveyRating)
        {
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
        public async Task<ActionResult<IEnumerable<object>>> GetAllRatings()
        {
            var surveyRatings = await _surveyRatingService.GetAllSurveyRatingsAsync();

            return Ok(surveyRatings);
        }
    }
}
