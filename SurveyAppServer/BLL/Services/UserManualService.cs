using BLL.Exceptions;
using Domain;
using Domain.Models.Surveys;

namespace BLL.Services;

public class UserManualService : IUserManualService
{
    private const string UserManualTarget = "UserManual";
    
    private readonly IUserManualRepository _userManualRepository;

    public UserManualService(IUserManualRepository userManualRepository)
    {
        _userManualRepository = userManualRepository;
    }

    // CRUD
    public async Task<UserManual> CreateUserManualAsync(UserManual userManual)
    {
        return await _userManualRepository.CreateAsync(userManual);
    }

    public async Task<UserManual> GetUserManualAsync(int userManualId)
    {
        var userManual = await _userManualRepository.GetByIdAsync(userManualId);

        if (userManual == null)
        {
            throw new EntityNotFoundException(UserManualTarget, userManualId);
        }

        return userManual;
    }

    public async Task UpdateUserManualAsync(UserManual userManual)
    {
        await _userManualRepository.UpdateAsync(userManual);
    }

    public async Task DeleteUserManualAsync(int userManualId)
    {
        await _userManualRepository.DeleteAsync(userManualId);
    }
    
    // Business logic
    public async Task<UserManual> GetUserManualBySurveyIdAsync(int surveyId)
    {
        var userManual = await _userManualRepository.GetBySurveyIdAsync(surveyId);

        if (userManual == null)
        {
            throw new EntityNotFoundException(UserManualTarget);
        }

        return userManual;
    }
}