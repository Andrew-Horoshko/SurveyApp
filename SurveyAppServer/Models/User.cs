namespace SurveyAppServer.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Survey> AccessibleSurveys { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Doctor,
        Patient,
    }

}
