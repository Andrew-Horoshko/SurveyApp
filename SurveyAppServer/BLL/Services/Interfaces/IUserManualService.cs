using Domain.Models.Surveys;

namespace BLL.Services;

public interface IUserManualService
{
    // CRUD
    Task<UserManual> CreateUserManualAsync(UserManual userManual);
    
    Task<UserManual> GetUserManualAsync(int userManualId);
    
    Task UpdateUserManualAsync(UserManual userManual);
    
    Task DeleteUserManualAsync(int userManualId);
    
    // Business logic
    Task<UserManual> GetUserManualBySurveyIdAsync(int surveyId);
}