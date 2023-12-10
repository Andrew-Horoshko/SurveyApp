using Domain;
using Domain.Models.Surveys;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class SurveyRatingRepository : BaseRepository<SurveyRating>, ISurveyRatingRepository
{
    public SurveyRatingRepository(SurveyAppDbContext context) : base(context) { }

    public async Task<IEnumerable<SurveyRating>> GetBySurveyIdAsync(int surveyId)
    {
        return await EntitySet
            .Where(r => r.SurveyId == surveyId)
            .ToListAsync();
    }
}