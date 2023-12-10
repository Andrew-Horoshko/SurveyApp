using Domain.Models.Answers;
using Domain.Models.Questions;
using Domain.Models.Surveys;
using Domain.Models.Users;

namespace DAL;

public sealed class DbSeeder
{
    private static DbSeeder? _instance;

    public static DbSeeder GetInstance()
    {
        return _instance ??= new DbSeeder();
    }
    
    private DbSeeder() {
        SingleChoiceQuestions = new List<SingleChoiceQuestion>
        {
            new()
            {
                QuestionId = 1,
                Text = "How many oceans are there?",
                Tooltip = "This test aims to asses your memory (1)",
                HasRightAnswer = true,
                SurveyId = 1
            },
            new()
            {
                QuestionId = 2,
                Text = "How many continents are there?",
                Tooltip = "This test aims to asses your memory (2)",
                HasRightAnswer = true,
                SurveyId = 1
            }
        };

        MultipleChoiceQuestions = new List<MultipleChoiceQuestion>
        {
            new()
            {
                QuestionId = 3,
                Text = "When do you feel most hungry?",
                Tooltip = "This question helps to asses your digestion system's health",
                HasRightAnswer = false,
                SurveyId = 1
            }
        };

        OpenTextQuestions = new List<OpenTextQuestion>
        {
            new()
            {
                QuestionId = 4,
                Text = "Tell us about your before bed routine",
                Tooltip = "This question aims to asses the quality of your sleep",
                HasRightAnswer = false,
                SurveyId = 1
            }
        };

        Answers = new List<Answer>
        {
            // Question 1 (single-choice)
            new() { AnswerId = 1, Text = "3", IsCorrect = false, QuestionId = 1 },
            new() { AnswerId = 2, Text = "4", IsCorrect = true, QuestionId = 1 },
            new() { AnswerId = 3, Text = "5", IsCorrect = false, QuestionId = 1 },
            
            // Question 2 (single-choice)
            new() { AnswerId = 4, Text = "7", IsCorrect = true, QuestionId = 2 },
            new() { AnswerId = 5, Text = "6", IsCorrect = false, QuestionId = 2 },
            new() { AnswerId = 6, Text = "5", IsCorrect = false, QuestionId = 2 },
            
            // Question 3 (multiple-choice)
            new() { AnswerId = 7, Text = "In the morning",  QuestionId = 3 },
            new() { AnswerId = 8, Text = "In the afternoon",  QuestionId = 3 },
            new() { AnswerId = 9, Text = "At night",  QuestionId = 3 },
        };

        Users = new List<User>
        {
            new()
            {
                UserId = 1,
                Username = "admin0",
                Email = "admin0@admin.com",
                Password = "pass123",
                Role = UserRole.Admin
            }
        };
        
        Surveys = new List<Survey>
        {
            new() { SurveyId = 1, Title = "Mock survey", AverageRating = 2.4 }
        };

        SurveyAttempts = new List<SurveyAttempt>
        {
            new() { SurveyAttemptId = 1, AttemptDate = DateTime.Now, SurveyId = 1, UserId = 1 }
        };

        SurveyAnswers = new List<SurveyAnswer>
        {
            new() { SurveyAnswerId = 1, SurveyAttemptId = 1, QuestionId = 1, AnswerId = 1 },
            new() { SurveyAnswerId = 2, SurveyAttemptId = 1, QuestionId = 2, AnswerId = 6 },
            new()
            {
                SurveyAnswerId = 3, 
                SurveyAttemptId = 1, 
                QuestionId = 3, 
                AnswerId = 1, // TODO: this has to be nullable or we should create an OpenAnswer entity
                OpenAnswer = "I read a book."
            }
        };

        SurveyRatings = new List<SurveyRating>
        {
            new() { SurveyRatingId = 1, Mark = SurveyMarks.Ok, SurveyId = 1, UserId = 1 }
        };

        UserManuals = new List<UserManual>
        {
            new()
            {
                UserManualId = 1,
                Title = "Mock survey manual",
                Content = "This is a mock survey manual",
                SurveyId = 1
            }
        };
    }

    // Questions
    public IList<SingleChoiceQuestion> SingleChoiceQuestions { get; private set; }
    public IList<MultipleChoiceQuestion> MultipleChoiceQuestions { get; private set; }
    public IList<OpenTextQuestion> OpenTextQuestions { get; private set; }

    public IList<Answer> Answers { get; private set; }

    // Survey-related
    public IList<Survey> Surveys { get; private set; }
    public IList<SurveyAnswer> SurveyAnswers { get; private set; }
    public IList<SurveyAttempt> SurveyAttempts { get; private set; }
    public IList<SurveyRating> SurveyRatings { get; private set; }
    public IList<UserManual> UserManuals { get; private set; }
    
    // Users
    public IList<User> Users { get; private set; }
}