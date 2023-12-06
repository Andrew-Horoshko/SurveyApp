namespace SurveyAppServer.Models.Surveys;

// TODO: add a system manual
public class UserManual
{
    public int UserManualId { get; set; }
    public string Content { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
}