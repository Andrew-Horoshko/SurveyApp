using Domain.Models.Answers;

namespace Domain.Models.Questions;

public class MultipleChoiceQuestion : QuestionBase
{
    public ICollection<Answer>? Answers { get; set; }
}