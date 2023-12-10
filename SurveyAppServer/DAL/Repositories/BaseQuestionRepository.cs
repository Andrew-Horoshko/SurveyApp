using Domain;
using Domain.Models.Questions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BaseQuestionRepository : BaseRepository<BaseQuestion>, IBaseQuestionRepository
{
    public BaseQuestionRepository(SurveyAppDbContext context) : base(context) { }

    public async Task<BaseQuestion?> GetByIdIncludeAnswersAsync(int questionId)
    {
        return await EntitySet
            .Include(q => q.Answers)
            .FirstOrDefaultAsync(q => q.QuestionId == questionId);
    }
}