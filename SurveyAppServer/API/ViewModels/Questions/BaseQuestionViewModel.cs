using SurveyAppServer.ViewModels.Answers;

namespace SurveyAppServer.ViewModels.Questions;

public class BaseQuestionViewModel
{
    public int QuestionId { get; set; }
    public string Text { get; set; } = null!;
    public string Tooltip { get; set; } = null!;
    public bool HasRightAnswer { get; set; }
    public string QuestionType { get; set; } = null!;
    public int SurveyId { get; set; }
    public ICollection<AnswerViewModel> Answers { get; set; } = null!;
}