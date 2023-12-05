using System.ComponentModel.DataAnnotations;

namespace SurveyAppServer.Models.Questions;

using Surveys;

public abstract class QuestionBase
{
    [Key]
    public int QuestionId { get; set; }
    public string Tooltip { get; set; } = null!;
    public int SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
}