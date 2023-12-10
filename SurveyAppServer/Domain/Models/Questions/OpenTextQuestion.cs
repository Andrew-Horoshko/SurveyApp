namespace Domain.Models.Questions;

public class OpenTextQuestion : BaseQuestion
{
    public OpenTextQuestion()
    {
        QuestionType = Domain.QuestionType.OpenText;
    }

    public override string ToString()
    {
        return $"{base.ToString()} (write your answer below)";
    }

    public override double CalculateChance()
    {
        return 1;
    }
}