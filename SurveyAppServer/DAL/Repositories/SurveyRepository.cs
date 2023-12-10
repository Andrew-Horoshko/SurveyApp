using Domain;
using Domain.Models.Questions;
using Domain.Models.Surveys;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class SurveyRepository : BaseRepository<Survey>, ISurveyRepository
{
    public SurveyRepository(SurveyAppDbContext context) : base(context) { }

    public async Task<Survey?> GetByIdIncludeQuestions(int surveyId)
    {
        return await EntitySet
            .Include(s => s.Questions)
            .ThenInclude(q => (q as SingleChoiceQuestion)!.Answers)
            .Include(s => s.Questions)
            .ThenInclude(q => (q as MultipleChoiceQuestion)!.Answers)
            .Include(s => s.Questions)
            .FirstOrDefaultAsync(s => s.SurveyId == surveyId);
    }
}