namespace Domain.Models.Questions;

public class SingleChoiceQuestion : BaseQuestion
{
    public SingleChoiceQuestion()
    {
        QuestionType = Domain.QuestionType.SingleChoice;
    }
    
    public override string ToString()
    {
        var answers = string.Join(", ", Answers.Select(a => a.Text));

        return $"{base.ToString()}\n{answers}";
    }

    public override double CalculateChance()
    {
        if (!HasRightAnswer)
        {
            return 1;
        }

        return 1 / (double) Answers.Count;
    }
}