using Domain;
using Domain.Models.Surveys;

namespace BLL.Services;

public class UserManualService : IUserManualService
{
    private readonly IUserManualRepository _userManualRepository;

    public UserManualService(IUserManualRepository userManualRepository)
    {
        _userManualRepository = userManualRepository;
    }

    public async Task<UserManual> GetUserManualBySurveyId(int surveyId)
    {
        var userManual = await _userManualRepository.GetBySurveyId(surveyId);

        if (userManual == null)
        {
            throw new Exception($"User manual for survey with id {surveyId} is not found: 404");
        }

        return userManual;
    }
}