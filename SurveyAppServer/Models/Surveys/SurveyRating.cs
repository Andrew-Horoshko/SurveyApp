using SurveyAppServer.Models.Users;

namespace SurveyAppServer.Models.Surveys;

public enum SurveyMarks
{
    VeryLow,
    Low,
    Medium,
    Good,
    VeryGood
}

public class SurveyRating
{
    public int SurveyRatingId { get; set; }
    public int SurveyId { get; set; }
    public int UserId { get; set; }
    public SurveyMarks Mark { get; set; }
    public Survey Survey { get; set; } = null!;
    public User User { get; set; } = null!;
}