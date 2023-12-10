using Domain;
using Domain.Models.Surveys;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class SurveyRepository : BaseRepository<Survey>, ISurveyRepository
{
    public SurveyRepository(SurveyAppDbContext context) : base(context) { }

    public async Task<Survey?> GetByIdIncludeQuestionsAsync(int surveyId)
    {
        return await EntitySet
            .Include(s => s.Questions)
            .FirstOrDefaultAsync(s => s.SurveyId == surveyId);
    }
}