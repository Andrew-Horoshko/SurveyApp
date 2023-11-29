namespace SurveyAppServer.Models
{
    public class SurveyRating
    {
        public int SurveyRatingId { get; set; }
        public int SurveyId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; } // Rating value from 1 to 5
        public Survey Survey { get; set; }
        public User User { get; set; }
    }

}
