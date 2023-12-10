using Domain.Models.Surveys;

using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Questions;

public class QuestionBase
{
    [Key]
    public int QuestionId { get; set; }
    public string Text { get; set; } = null!;
    public string Tooltip { get; set; } = null!;
    public bool HasRightAnswer { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
}