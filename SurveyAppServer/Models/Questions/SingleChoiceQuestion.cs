using SurveyAppServer.Models.Answers;

namespace SurveyAppServer.Models.Questions;

public class SingleChoiceQuestion : QuestionBase
{
    public Answer? Answer { get; set; }
}