using BLL.Services.Interfaces;
using Domain.Models.Answers;
using SurveyAppServer.ViewModels.Answers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SurveyAppServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerController : Controller
{
    private readonly IAnswerService _answerService;
    private readonly IMapper _mapper;

    public AnswerController(IAnswerService answerService, IMapper mapper)
    {
        _answerService = answerService;
        _mapper = mapper;
    }
    
    // CRUD
    [HttpGet]
    public async Task<ActionResult<AnswerViewModel>> GetAnswer(int answerId)
    {
        var answer = await _answerService.GetAnswerAsync(answerId);

        var answerViewModel = _mapper.Map<AnswerViewModel>(answer);

        return Ok(answerViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<AnswerViewModel>> CreateAnswer(AnswerViewModel answerViewModel)
    {
        var answer = _mapper.Map<Answer>(answerViewModel);

        answer = await _answerService.CreateAnswerAsync(answer);

        answerViewModel = _mapper.Map<AnswerViewModel>(answer);

        return Ok(answerViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAnswer(AnswerViewModel answerViewModel)
    {
        var answer = _mapper.Map<Answer>(answerViewModel);

        await _answerService.UpdateAnswerAsync(answer);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAnswer(int answerId)
    {
        await _answerService.DeleteAnswerAsync(answerId);

        return NoContent();
    }
}