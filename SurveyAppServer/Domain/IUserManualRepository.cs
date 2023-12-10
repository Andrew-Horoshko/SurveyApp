using Domain.Models.Surveys;

namespace Domain;

public interface IUserManualRepository : IBaseRepository<UserManual>
{
    Task<UserManual?> GetBySurveyIdAsync(int surveyId);
}