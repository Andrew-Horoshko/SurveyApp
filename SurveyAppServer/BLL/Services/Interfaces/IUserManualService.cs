using Domain.Models.Surveys;

namespace BLL.Services;

public interface IUserManualService
{
    Task<UserManual> GetUserManualBySurveyId(int surveyId);
}