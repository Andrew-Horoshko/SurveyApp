using Domain.Models.Surveys;

using System.ComponentModel.DataAnnotations;
using Domain.Models.Answers;

namespace Domain.Models.Questions;

public class BaseQuestion
{
    [Key]
    public int QuestionId { get; set; }
    public string Text { get; set; } = null!;
    public string Tooltip { get; set; } = null!;
    public bool HasRightAnswer { get; set; }
    public string QuestionType { get; set; } = null!; // Discriminator
    public int SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
    public ICollection<Answer> Answers { get; set; } = null!;

    public override string ToString()
    {
        return $"{QuestionId}. {Text} ({Tooltip})";
    }

    public virtual double CalculateChance()
    {
        return 0;
    }
}