namespace SurveyAppServer.Models
{
    public class SurveyAnswer
    {
        public int SurveyAnswerId { get; set; }
        public string AnswerText { get; set; } // This could be text, or the ID of a chosen option
        public int SurveyAttemptId { get; set; }
        public SurveyAttempt SurveyAttempt { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
