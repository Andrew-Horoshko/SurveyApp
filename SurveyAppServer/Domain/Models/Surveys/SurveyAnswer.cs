using Domain.Models.Answers;
using Domain.Models.Questions;

namespace Domain.Models.Surveys;

public class SurveyAnswer
{
    public int SurveyAnswerId { get; set; }
    public string? OpenAnswer { get; set; }
    public int SurveyAttemptId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public SurveyAttempt SurveyAttempt { get; set; } = null!;
    public BaseQuestion Question { get; set; } = null!;
    public Answer Answer { get; set; } = null!;
}