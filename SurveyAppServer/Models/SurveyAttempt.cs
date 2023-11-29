namespace SurveyAppServer.Models
{
    public class SurveyAttempt
    {
        public int SurveyAttemptId { get; set; }
        public DateTime AttemptDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public ICollection<SurveyAnswer> SurveyAnswers { get; set; }
    }

}
