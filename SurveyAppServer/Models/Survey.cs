namespace SurveyAppServer.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public double AverageRating { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<User> AccessibleByUsers { get; set; }
        public UserManual UserManual { get; set; }
    }
}
