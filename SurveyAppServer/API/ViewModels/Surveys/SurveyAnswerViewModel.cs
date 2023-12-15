namespace SurveyAppServer.ViewModels;

public class SurveyAnswerViewModel
{
    public int SurveyAnswerId { get; set; }
    public string? OpenAnswer { get; set; }
    public int SurveyAttemptId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
}