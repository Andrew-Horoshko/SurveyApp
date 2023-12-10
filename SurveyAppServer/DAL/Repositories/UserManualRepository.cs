using Domain;
using Domain.Models.Surveys;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserManualRepository : BaseRepository<UserManual>, IUserManualRepository
{
    public UserManualRepository(SurveyAppDbContext context) : base(context) { }

    public async Task<UserManual?> GetBySurveyIdAsync(int surveyId)
    {
        return await EntitySet.FirstOrDefaultAsync(um => um.SurveyId == surveyId);
    }
}