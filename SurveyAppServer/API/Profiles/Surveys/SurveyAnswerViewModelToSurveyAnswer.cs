using AutoMapper;
using Domain.Models.Surveys;
using SurveyAppServer.ViewModels;

namespace SurveyAppServer.Profiles.Surveys;

public class SurveyAnswerViewModelToSurveyAnswer : Profile
{
    public SurveyAnswerViewModelToSurveyAnswer()
    {
        CreateMap<SurveyAnswerViewModel, SurveyAnswer>().ReverseMap();
    }
}