namespace Domain.Models.Questions;

public class SingleChoiceQuestion : BaseQuestion
{
    public SingleChoiceQuestion()
    {
        QuestionType = Domain.QuestionType.SingleChoice;
    }
    
    public override string GetAnswers()
    {
        return string.Join(", ", Answers.Select(a => a.Text));
    }

    public override double CalculateOdds()
    {
        if (!HasRightAnswer)
        {
            return 1;
        }

        return 1 / (double) Answers.Count;
    }
}