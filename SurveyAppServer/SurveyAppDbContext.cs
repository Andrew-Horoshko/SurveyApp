using Microsoft.EntityFrameworkCore;
using SurveyAppServer.Models.Answers;
using SurveyAppServer.Models.Questions;
using SurveyAppServer.Models.Surveys;
using SurveyAppServer.Models.Users;

namespace SurveyAppServer;

public class SurveyAppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    // Questions
    public DbSet<QuestionBase> Questions { get; set; } = null!;
    public DbSet<SingleChoiceQuestion> SingleChoiceQuestions { get; set; } = null!;
    public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; } = null!;
    public DbSet<OpenTextQuestion> OpenTextQuestions { get; set; } = null!;

    public DbSet<Answer> Answers { get; set; } = null!;

    // Survey-related
    public DbSet<Survey> Surveys { get; set; } = null!;
    public DbSet<SurveyAttempt> SurveyAttempts { get; set; } = null!;
    public DbSet<SurveyAnswer> SurveyAnswers { get; set; } = null!;
    public DbSet<SurveyRating> SurveyRatings { get; set; } = null!;
    public DbSet<UserManual> UserManuals { get; set; } = null!;

    public SurveyAppDbContext(DbContextOptions<SurveyAppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.AccessibleSurveys)
            .WithMany(s => s.AccessibleByUsers)
            .UsingEntity(j => j
                .ToTable("UserSurveys")
                .HasData(new { AccessibleByUsersUserId = 1, AccessibleSurveysSurveyId = 1 }))
            .HasData(DbSeeder.Users);

        modelBuilder.Entity<SingleChoiceQuestion>()
            .HasData(DbSeeder.SingleChoiceQuestions);

        modelBuilder.Entity<MultipleChoiceQuestion>()
            .HasData(DbSeeder.MultipleChoiceQuestions);

        modelBuilder.Entity<OpenTextQuestion>()
            .HasData(DbSeeder.OpenTextQuestions);

        modelBuilder.Entity<Answer>()
            .HasData(DbSeeder.Answers);

        modelBuilder.Entity<Survey>()
            .HasMany(s => s.Questions)
            .WithOne(q => q.Survey)
            .HasForeignKey(q => q.SurveyId);
        modelBuilder.Entity<Survey>()
            .HasOne(s => s.UserManual) 
            .WithOne(um => um.Survey)  
            .HasForeignKey<UserManual>(um => um.SurveyId); 
        modelBuilder.Entity<Survey>()
            .HasData(DbSeeder.Surveys);

        modelBuilder.Entity<SurveyAttempt>()
            .HasMany(sa => sa.SurveyAnswers)
            .WithOne(a => a.SurveyAttempt)
            .HasForeignKey(a => a.SurveyAttemptId);
        modelBuilder.Entity<SurveyAttempt>()
            .HasData(DbSeeder.SurveyAttempts);
        
        modelBuilder.Entity<SurveyAnswer>()
            .HasData(DbSeeder.SurveyAnswers);

        modelBuilder.Entity<SurveyRating>()
            .HasData(DbSeeder.SurveyRatings);

        modelBuilder.Entity<UserManual>()
            .HasData(DbSeeder.UserManuals);
    }
}