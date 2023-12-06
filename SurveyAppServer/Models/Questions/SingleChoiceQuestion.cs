using SurveyAppServer.Models.Answers;

namespace SurveyAppServer.Models.Questions;

public class SingleChoiceQuestion : QuestionBase
{
    public ICollection<Answer> Answers { get; set; } = null!;
}