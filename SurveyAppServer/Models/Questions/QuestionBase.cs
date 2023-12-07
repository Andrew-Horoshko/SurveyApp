using System.ComponentModel.DataAnnotations;

namespace SurveyAppServer.Models.Questions;

using Surveys;

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