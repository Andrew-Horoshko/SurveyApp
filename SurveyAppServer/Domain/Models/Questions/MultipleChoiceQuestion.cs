namespace Domain.Models.Questions;

public class MultipleChoiceQuestion : BaseQuestion
{
    public MultipleChoiceQuestion()
    {
        QuestionType = Domain.QuestionType.MultipleChoice;
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

        var correctAnswersCount = Answers.Count(a => a.IsCorrect);
        return correctAnswersCount / (double) Answers.Count;
    }
}