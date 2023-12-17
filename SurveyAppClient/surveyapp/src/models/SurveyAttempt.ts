interface SurveyAttempt {
    surveyAttemptId: number;
    userId: number;
    surveyId: number;
    surveyAnswers: SurveyAnswer[];
}