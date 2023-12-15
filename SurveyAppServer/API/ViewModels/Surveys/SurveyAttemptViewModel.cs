namespace SurveyAppServer.ViewModels;

public class SurveyAttemptViewModel
{
    public int SurveyAttemptId { get; set; }
    public int UserId { get; set; }
    public int SurveyId { get; set; }
    public ICollection<SurveyAnswerViewModel> SurveyAnswers { get; set; } = null!;
}