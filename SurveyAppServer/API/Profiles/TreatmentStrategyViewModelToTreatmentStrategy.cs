using Domain.Models;
using SurveyAppServer.ViewModels;

using AutoMapper;

namespace SurveyAppServer.Profiles;

public class TreatmentStrategyViewModelToTreatmentStrategy : Profile
{
    public TreatmentStrategyViewModelToTreatmentStrategy()
    {
        CreateMap<TreatmentStrategyViewModel, TreatmentStrategy>().ReverseMap();
    }
}