using BLL.Services;
using BLL.Services.Interfaces;
using DAL;
using DAL.Repositories;
using Domain;
using Domain.Models.Surveys;

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
        services.AddScoped<IBaseQuestionRepository, BaseQuestionRepository>();
        services.AddScoped<IBaseRepository<SurveyAttempt>, BaseRepository<SurveyAttempt>>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<ISurveyRatingRepository, SurveyRatingRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserManualRepository, UserManualRepository>();
        
        // Services
        services.AddScoped<IQuestionBaseService, QuestionBaseService>();
        services.AddScoped<ISurveyService, SurveyService>();
        services.AddScoped<ISurveyRatingService, SurveyRatingService>();
        services.AddScoped<IUserManualService, UserManualService>();
    }
}