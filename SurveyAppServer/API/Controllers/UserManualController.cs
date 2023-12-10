using BLL.Services;
using Domain.Models.Surveys;

using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace SurveyAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManualController : ControllerBase
    {
        private readonly IUserManualService _userManualService;

        public UserManualController(IUserManualService userManualService)
        {
            _userManualService = userManualService;
        }

        [HttpGet("SurveyManual/{surveyId}")]
        public async Task<ActionResult<UserManual>> GetSurveyManual(int surveyId)
        {
            var surveyManual = _userManualService.GetUserManualBySurveyId(surveyId);

            return Ok(surveyManual);
        }

        [HttpPost("SendQuestion")]
        public ActionResult SendQuestion(string userEmail, string question)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.example.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("username@example.com", "password"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("noreply@example.com"),
                    Subject = "User Question",
                    Body = $"From: {userEmail}\n\n{question}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add("support@example.com");

                smtpClient.Send(mailMessage);

                return Ok("Question sent successfully.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Failed to send the question.");
            }
        }
    }
}
