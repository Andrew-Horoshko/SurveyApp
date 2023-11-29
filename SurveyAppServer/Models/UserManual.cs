namespace SurveyAppServer.Models
{
    public class UserManual
    {
        public int UserManualId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int? SurveyId { get; set; }
        public Survey Survey { get; set; }
    }

}
