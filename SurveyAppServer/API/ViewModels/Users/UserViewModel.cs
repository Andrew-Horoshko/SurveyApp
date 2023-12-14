using Domain.Models.Users;

namespace SurveyAppServer.ViewModels.Users;

public class UserViewModel
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole Role { get; set; }
}