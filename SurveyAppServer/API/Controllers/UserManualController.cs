using BLL.Services;
using Domain.Models.Surveys;

using System.Net.Mail;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyAppServer.ViewModels;

namespace SurveyAppServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserManualController : ControllerBase
{
    private readonly IUserManualService _userManualService;
    private readonly IMapper _mapper;

    public UserManualController(IUserManualService userManualService, IMapper mapper)
    {
        _userManualService = userManualService;
        _mapper = mapper;
    }

    // CRUD
    [HttpGet]
    public async Task<ActionResult<UserManualViewModel>> GetUserManual(int userManualId)
    {
        var userManual = await _userManualService.GetUserManualAsync(userManualId);

        var userManualViewModel = _mapper.Map<UserManualViewModel>(userManual);
        
        return Ok(userManualViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<UserManualViewModel>> CreateUserManual(UserManualViewModel userManualViewModel)
    {
        var userManual = _mapper.Map<UserManual>(userManualViewModel);
        
        userManual = await _userManualService.CreateUserManualAsync(userManual);

        userManualViewModel = _mapper.Map<UserManualViewModel>(userManual);
        
        return Ok(userManualViewModel);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUserManual(UserManualViewModel userManualViewModel)
    {
        var userManual = _mapper.Map<UserManual>(userManualViewModel);
        
        await _userManualService.UpdateUserManualAsync(userManual);

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUserManual(int userManualId)
    {
        await _userManualService.DeleteUserManualAsync(userManualId);

        return NoContent();
    }
        
    // Business logic
    [HttpGet("SurveyManual/{surveyId}")]
    public async Task<ActionResult<UserManualViewModel>> GetSurveyManual(int surveyId)
    {
        var surveyManual = await _userManualService.GetUserManualBySurveyIdAsync(surveyId);

        var surveyManualViewModel = _mapper.Map<UserManualViewModel>(surveyManual);
        
        return Ok(surveyManualViewModel);
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