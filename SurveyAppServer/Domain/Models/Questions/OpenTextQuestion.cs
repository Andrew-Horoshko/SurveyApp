namespace Domain.Models.Questions;

public class OpenTextQuestion : BaseQuestion
{
    public OpenTextQuestion()
    {
        QuestionType = Domain.QuestionType.OpenText;
    }

    public override string GetAnswers()
    {
        return "Please write your answer here: ";
    }

    public override double CalculateOdds()
    {
        return 1;
    }
}