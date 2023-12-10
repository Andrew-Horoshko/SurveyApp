using Domain.Models.Answers;
using Domain.Models.Questions;
using Domain.Models.Surveys;
using Domain.Models.Users;

using Microsoft.EntityFrameworkCore;

namespace DAL;

public class SurveyAppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    // Questions
    public DbSet<BaseQuestion> Questions { get; set; } = null!;
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
        var dbSeeder = MockDataStorage.GetInstance();
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.AccessibleSurveys)
            .WithMany(s => s.AccessibleByUsers)
            .UsingEntity(j => j
                .ToTable("UserSurveys")
                .HasData(new { AccessibleByUsersUserId = 1, AccessibleSurveysSurveyId = 1 }))
            .HasData(dbSeeder.Users);

        modelBuilder.Entity<SingleChoiceQuestion>()
            .HasData(dbSeeder.SingleChoiceQuestions);

        modelBuilder.Entity<MultipleChoiceQuestion>()
            .HasData(dbSeeder.MultipleChoiceQuestions);

        modelBuilder.Entity<OpenTextQuestion>()
            .HasData(dbSeeder.OpenTextQuestions);

        modelBuilder.Entity<Answer>()
            .HasData(dbSeeder.Answers);

        modelBuilder.Entity<Survey>()
            .HasMany(s => s.Questions)
            .WithOne(q => q.Survey)
            .HasForeignKey(q => q.SurveyId);
        modelBuilder.Entity<Survey>()
            .HasOne(s => s.UserManual) 
            .WithOne(um => um.Survey)  
            .HasForeignKey<UserManual>(um => um.SurveyId); 
        modelBuilder.Entity<Survey>()
            .HasData(dbSeeder.Surveys);

        modelBuilder.Entity<SurveyAttempt>()
            .HasMany(sa => sa.SurveyAnswers)
            .WithOne(a => a.SurveyAttempt)
            .HasForeignKey(a => a.SurveyAttemptId);
        modelBuilder.Entity<SurveyAttempt>()
            .HasData(dbSeeder.SurveyAttempts);
        
        modelBuilder.Entity<SurveyAnswer>()
            .HasData(dbSeeder.SurveyAnswers);

        modelBuilder.Entity<SurveyRating>()
            .HasData(dbSeeder.SurveyRatings);

        modelBuilder.Entity<UserManual>()
            .HasData(dbSeeder.UserManuals);
    }
}