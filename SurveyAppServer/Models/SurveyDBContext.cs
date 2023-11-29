using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SurveyAppServer.Models
{
    public class SurveyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<SurveyAttempt> SurveyAttempts { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<SurveyRating> SurveyRatings { get; set; }
        public DbSet<UserManual> UserManuals { get; set; }

        public SurveyDbContext(DbContextOptions<SurveyDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.AccessibleSurveys)
                .WithMany(s => s.AccessibleByUsers)
                .UsingEntity(j => j.ToTable("UserSurveys")); 

            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.AnswerOptions)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<SurveyAttempt>()
                .HasMany(sa => sa.SurveyAnswers)
                .WithOne(a => a.SurveyAttempt)
                .HasForeignKey(a => a.SurveyAttemptId);

            modelBuilder.Entity<Survey>()
              .HasOne(s => s.UserManual) 
              .WithOne(um => um.Survey)  
              .HasForeignKey<UserManual>(um => um.SurveyId); 
        }
    }

}
