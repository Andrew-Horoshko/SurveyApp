﻿using SurveyAppServer.Models.Answers;
using SurveyAppServer.Models.Questions;

namespace SurveyAppServer.Models.Surveys;

public class SurveyAnswer
{
    public int SurveyAnswerId { get; set; }
    public string? OpenAnswer { get; set; }
    public int SurveyAttemptId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public SurveyAttempt SurveyAttempt { get; set; } = null!;
    public QuestionBase Question { get; set; } = null!;
    public Answer Answer { get; set; } = null!;
}