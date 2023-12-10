using Domain.Models.Surveys;
using Domain.Models.Users;

namespace Domain;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByIdIncludeSurveys(int userId);
}