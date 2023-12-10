using BLL.Services;
using DAL;
using DAL.Repositories;
using Domain;
using Domain.Models.Surveys;

public static class ServicesConfiguration
{
    private static IConfiguration _configuration;

    public static void Initialize(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static void AddAppServices(this IServiceCollection services)
    {
        // Database context
        services.AddDbContext<SurveyAppDbContext>();
        
        // Repositories
        services.AddScoped<IBaseRepository<SurveyAttempt>, BaseRepository<SurveyAttempt>>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserManualRepository, UserManualRepository>();
        
        // Services
        services.AddScoped<ISurveyService, SurveyService>();
        services.AddScoped<IUserManualService, UserManualService>();
    }
}
