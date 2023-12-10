using Domain.Models.Questions;

namespace Domain.Models.Answers;

// TODO: split into Answer and OpenAnswer
public class Answer
{
    public int AnswerId { get; set; }
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }
    public int QuestionId { get; set; }
    public QuestionBase Question { get; set; } = null!;
}