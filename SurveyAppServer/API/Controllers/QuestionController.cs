using BLL.Services.Interfaces;
using Domain.Models.Answers;
using Microsoft.AspNetCore.Mvc;

namespace SurveyAppServer.Controllers;

public class QuestionController : ControllerBase
{
    private readonly IQuestionBaseService _questionBaseService;

    public QuestionController(IQuestionBaseService questionBaseService)
    {
        _questionBaseService = questionBaseService;
    }

    [HttpGet("Answers")]
    public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers(int questionId)
    {
        var answers = await _questionBaseService.GetQuestionAnswersAsync(questionId);

        return Ok(answers);
    }

    [HttpGet("Description")]
    public async Task<ActionResult<string>> GetDescription(int questionId)
    {
        string description = await _questionBaseService.GetQuestionDescriptionAsync(questionId);

        return Ok(description);
    }
}