using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net.Mail;
using SurveyAppServer.Models;
using SurveyAppServer.Models.Surveys;

namespace SurveyAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManualController : ControllerBase
    {
        private readonly SurveyAppDbContext _context;

        public UserManualController(SurveyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Survey/{surveyId}")]
        public async Task<ActionResult<UserManual>> GetSurveyManual(int surveyId)
        {
            var manual = await _context.UserManuals.FirstOrDefaultAsync(um => um.SurveyId == surveyId);
            if (manual == null)
            {
                return NotFound("Manual for the specified survey not found.");
            }

            return manual;
        }

        [HttpGet("General")]
        public async Task<ActionResult<UserManual>> GetGeneralManual()
        {
            var manual = await _context.UserManuals.FirstOrDefaultAsync(um => um.SurveyId == null);
            if (manual == null)
            {
                return NotFound("General manual not found.");
            }

            return manual;
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
