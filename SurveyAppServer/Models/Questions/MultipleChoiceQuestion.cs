using SurveyAppServer.Models.Answers;

namespace SurveyAppServer.Models.Questions;

public class MultipleChoiceQuestion : QuestionBase
{
    public ICollection<Answer>? Answers { get; set; }
}