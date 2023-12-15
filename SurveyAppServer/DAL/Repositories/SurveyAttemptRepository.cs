using Domain;
using Domain.Models.Surveys;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class SurveyAttemptRepository : BaseRepository<SurveyAttempt>, ISurveyAttemptRepository
{
    public SurveyAttemptRepository(SurveyAppDbContext context) : base(context) { }

    public async Task<SurveyAttempt?> GetByIdIncludeAnswersAsync(int surveyAttemptId)
    {
        return await EntitySet
            .Include(s => s.SurveyAnswers)
            .FirstOrDefaultAsync(s => s.SurveyAttemptId == surveyAttemptId);
    }
}