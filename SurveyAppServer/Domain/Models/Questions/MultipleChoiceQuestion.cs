namespace Domain.Models.Questions;

public class MultipleChoiceQuestion : BaseQuestion
{
    public MultipleChoiceQuestion()
    {
        QuestionType = Domain.QuestionType.MultipleChoice;
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

        var correctAnswersCount = Answers.Count(a => a.IsCorrect);
        return correctAnswersCount / (double) Answers.Count;
    }
}