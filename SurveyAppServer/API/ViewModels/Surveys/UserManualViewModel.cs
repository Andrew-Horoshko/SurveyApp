namespace SurveyAppServer.View_Models;

public class UserManualViewModel
{
    public int UserManualId { get; set; }
    public string Content { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int SurveyId { get; set; }
}