namespace SurveyAppServer.View_Models;

public class SurveyViewModel
{
    public int SurveyId { get; set; }
    public string Title { get; set; } = null!;
    public double AverageRating { get; set; }
}