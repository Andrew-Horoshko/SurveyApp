using Domain.Models.Users;

namespace Domain.Models.Surveys;

public enum SurveyMarks
{
    VeryBad,
    Bad,
    Ok,
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