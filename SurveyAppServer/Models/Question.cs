namespace SurveyAppServer.Models
{
    public enum QuestionType
    {
        Text,
        Choice,
        TrueFalse
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public string Tooltip { get; set; }
        public QuestionType Type { get; set; }
        public ICollection<AnswerOption> AnswerOptions { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
    }

}
