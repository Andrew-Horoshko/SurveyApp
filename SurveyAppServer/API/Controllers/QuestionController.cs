using BLL.Services.Interfaces;
using SurveyAppServer.ViewModels.Answers;

using AutoMapper;
using Domain.Models.Questions;
using Microsoft.AspNetCore.Mvc;
using SurveyAppServer.ViewModels.Questions;

namespace SurveyAppServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IBaseQuestionService _baseQuestionService;
    private readonly IMapper _mapper;

    public QuestionController(IBaseQuestionService baseQuestionService, IMapper mapper)
    {
        _baseQuestionService = baseQuestionService;
        _mapper = mapper;
    }

    // CRUD
    [HttpGet]
    public async Task<ActionResult<BaseQuestionViewModel>> GetQuestion(int questionId)
    {
        var question = await _baseQuestionService.GetQuestionAsync(questionId);

        var questionViewModel = _mapper.Map<BaseQuestionViewModel>(question);

        return Ok(questionViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<BaseQuestionViewModel>> CreateQuestion(BaseQuestionViewModel questionViewModel)
    {
        var question = _mapper.Map<BaseQuestion>(questionViewModel);

        question = await _baseQuestionService.CreateQuestionAsync(question);

        questionViewModel = _mapper.Map<BaseQuestionViewModel>(question);

        return Ok(questionViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateQuestion(BaseQuestionViewModel questionViewModel)
    {
        var question = _mapper.Map<BaseQuestion>(questionViewModel);

        await _baseQuestionService.UpdateQuestionAsync(question);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQuestion(int questionId)
    {
        await _baseQuestionService.DeleteQuestionAsync(questionId);

        return NoContent();
    }

    // Business logic
    [HttpGet("Answers")]
    public async Task<ActionResult<IEnumerable<AnswerViewModel>>> GetAnswers(int questionId)
    {
        var answers = await _baseQuestionService.GetQuestionAnswersAsync(questionId);

        var answerViewModels = answers.Select(a => _mapper.Map<AnswerViewModel>(a));
        
        return Ok(answerViewModels);
    }

    [HttpGet("Description")]
    public async Task<ActionResult<string>> GetDescription(int questionId)
    {
        string description = await _baseQuestionService.GetQuestionDescriptionAsync(questionId);

        return Ok(description);
    }
}