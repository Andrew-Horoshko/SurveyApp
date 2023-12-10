using Domain.Models.Users;

namespace Domain.Models.Surveys;

public class SurveyAttempt
{
    public int SurveyAttemptId { get; set; }
    public DateTime AttemptDate { get; set; }
    public int UserId { get; set; }
    public int SurveyId { get; set; }
    public User User { get; set; } = null!;
    public Survey Survey { get; set; } = null!;
    public ICollection<SurveyAnswer> SurveyAnswers { get; set; } = null!;
}