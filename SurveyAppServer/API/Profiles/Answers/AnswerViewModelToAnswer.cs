using AutoMapper;
using Domain.Models.Answers;
using SurveyAppServer.ViewModels.Answers;

namespace SurveyAppServer.Profiles.Answers;

public class AnswerViewModelToAnswer : Profile
{
    public AnswerViewModelToAnswer()
    {
        CreateMap<AnswerViewModel, Answer>().ReverseMap();
    }
}