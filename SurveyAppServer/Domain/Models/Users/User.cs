namespace Domain.Models.Users;

public enum UserRole
{
    Admin,
    Doctor,
    Patient,
}

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole Role { get; set; }
    public ICollection<Surveys.Survey> AccessibleSurveys { get; set; } = null!;
}