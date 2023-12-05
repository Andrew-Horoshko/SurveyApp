using SurveyAppServer.Models.Questions;

namespace SurveyAppServer.Models.Answers;

public class Answer
{
    public int AnswerId { get; set; }
    public string Text { get; set; } = null!;
    public int QuestionId { get; set; }
    public QuestionBase Question { get; set; } = null!;
}