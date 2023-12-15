using AutoMapper;
using Domain.Models.Surveys;
using SurveyAppServer.ViewModels;

namespace SurveyAppServer.Profiles.Surveys;

public class SurveyRatingViewModelToSurveyRating : Profile
{
    public SurveyRatingViewModelToSurveyRating()
    {
        CreateMap<SurveyRatingViewModel, SurveyRating>().ReverseMap();
    }
}