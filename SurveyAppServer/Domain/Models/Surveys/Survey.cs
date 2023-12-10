using Domain.Models.Questions;
using Domain.Models.Users;

namespace Domain.Models.Surveys;

public class Survey
{
    public int SurveyId { get; set; }
    public string Title { get; set; } = null!;
    public double AverageRating { get; set; }
    public ICollection<QuestionBase> Questions { get; set; } = null!;
    public ICollection<User> AccessibleByUsers { get; set; } = null!;
    public UserManual UserManual { get; set; } = null!;
}