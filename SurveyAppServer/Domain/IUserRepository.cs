using Domain.Models.Users;

namespace Domain;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByIdIncludeSurveysAsync(int userId);
}