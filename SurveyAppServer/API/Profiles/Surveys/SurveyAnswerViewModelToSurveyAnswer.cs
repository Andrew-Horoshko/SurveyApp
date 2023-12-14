using AutoMapper;
using Domain.Models.Surveys;
using SurveyAppServer.View_Models;

namespace SurveyAppServer.Profiles;

public class SurveyAnswerViewModelToSurveyAnswer : Profile
{
    public SurveyAnswerViewModelToSurveyAnswer()
    {
        CreateMap<SurveyAnswerViewModel, SurveyAnswer>();
    }
}