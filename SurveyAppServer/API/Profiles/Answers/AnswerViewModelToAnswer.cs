using AutoMapper;
using Domain.Models.Answers;
using SurveyAppServer.View_Models.Answers;

namespace SurveyAppServer.Profiles;

public class AnswerViewModelToAnswer : Profile
{
    public AnswerViewModelToAnswer()
    {
        CreateMap<AnswerViewModel, Answer>().ReverseMap();
    }
}