using BLL.Services.Interfaces;
using SurveyAppServer.ViewModels.Answers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SurveyAppServer.Controllers;

public class QuestionController : ControllerBase
{
    private readonly IQuestionBaseService _questionBaseService;
    private readonly IMapper _mapper;

    public QuestionController(IQuestionBaseService questionBaseService, IMapper mapper)
    {
        _questionBaseService = questionBaseService;
        _mapper = mapper;
    }

    [HttpGet("Answers")]
    public async Task<ActionResult<IEnumerable<AnswerViewModel>>> GetAnswers(int questionId)
    {
        var answers = await _questionBaseService.GetQuestionAnswersAsync(questionId);

        var answerViewModels = answers.Select(a => _mapper.Map<AnswerViewModel>(a));
        
        return Ok(answerViewModels);
    }

    [HttpGet("Description")]
    public async Task<ActionResult<string>> GetDescription(int questionId)
    {
        string description = await _questionBaseService.GetQuestionDescriptionAsync(questionId);

        return Ok(description);
    }
}