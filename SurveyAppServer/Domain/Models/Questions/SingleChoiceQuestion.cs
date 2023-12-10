using Domain.Models.Answers;

namespace Domain.Models.Questions;

public class SingleChoiceQuestion : QuestionBase
{
    public ICollection<Answer> Answers { get; set; } = null!;
}