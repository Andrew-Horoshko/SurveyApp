using Domain.Models.Questions;

namespace SurveyAppServer.View_Models.Answers;

public class AnswerViewModel
{
    public int AnswerId { get; set; }
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }
    public int QuestionId { get; set; }
}