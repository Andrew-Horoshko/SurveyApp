using AutoMapper;
using Domain.Models.Surveys;
using SurveyAppServer.ViewModels;

namespace SurveyAppServer.Profiles.Surveys;

public class SurveyAttemptViewModelToSurveyAttempt : Profile
{
    public SurveyAttemptViewModelToSurveyAttempt()
    {
        CreateMap<SurveyAttemptViewModel, SurveyAttempt>().ReverseMap();
    }
}