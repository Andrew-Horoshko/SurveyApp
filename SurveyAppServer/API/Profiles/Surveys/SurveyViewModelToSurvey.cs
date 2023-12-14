using AutoMapper;
using Domain.Models.Surveys;
using SurveyAppServer.ViewModels;

namespace SurveyAppServer.Profiles;

public class SurveyViewModelToSurvey : Profile
{
    public SurveyViewModelToSurvey()
    {
        CreateMap<SurveyViewModel, Survey>().ReverseMap();
    }
}