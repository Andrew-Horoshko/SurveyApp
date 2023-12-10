using Domain;
using Domain.Models.Surveys;
using Domain.Models.Users;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(SurveyAppDbContext context) : base(context) { }

    public async Task<User?> GetByIdIncludeSurveys(int userId)
    {
        return await EntitySet
            .Include(u => u.AccessibleSurveys)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }
}