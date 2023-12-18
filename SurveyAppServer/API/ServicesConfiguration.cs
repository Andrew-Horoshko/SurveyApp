using BLL.Services;
using BLL.Services.Interfaces;
using DAL;
using DAL.Repositories;
using Domain;
using Domain.Models;
using Domain.Models.Answers;
using SurveyAppServer.Profiles;
using SurveyAppServer.Profiles.Answers;
using SurveyAppServer.Profiles.Questions;
using SurveyAppServer.Profiles.Surveys;
using SurveyAppServer.Profiles.Users;

namespace SurveyAppServer;

public static class ServicesConfiguration
{
    private static IConfiguration? _configuration;

    public static void Initialize(IConfiguration? configuration)
    {
        _configuration = configuration;
    }

    public static void AddAppServices(this IServiceCollection services)
    {
        // Database context
        services.AddDbContext<SurveyAppDbContext>();
        
        // Repositories
        services.AddScoped<IBaseRepository<Answer>, BaseRepository<Answer>>();
        services.AddScoped<IBaseQuestionRepository, BaseQuestionRepository>();
        services.AddScoped<ISurveyAttemptRepository, SurveyAttemptRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<ISurveyRatingRepository, SurveyRatingRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserManualRepository, UserManualRepository>();
        services.AddScoped<IBaseRepository<TreatmentStrategy>, BaseRepository<TreatmentStrategy>>();

        // Services
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<IBaseQuestionService, BaseQuestionService>();
        services.AddScoped<ISurveyService, SurveyService>();
        services.AddScoped<ISurveyRatingService, SurveyRatingService>();
        services.AddScoped<IUserManualService, UserManualService>();
        services.AddScoped<ITreatmentStrategyService, TreatmentStrategyService>();
        
        // Automapper
        services.AddAutoMapper(
            typeof(BaseQuestionViewModelToBaseQuestion),
            typeof(AnswerViewModelToAnswer),
            typeof(SurveyAnswerViewModelToSurveyAnswer),
            typeof(SurveyAttemptViewModelToSurveyAttempt),
            typeof(SurveyViewModelToSurvey),
            typeof(SurveyRatingViewModelToSurveyRating),
            typeof(UserManualViewModelToUserManual),
            typeof(UserViewModelToUser),
            typeof(TreatmentStrategyViewModelToTreatmentStrategy));
    }
}