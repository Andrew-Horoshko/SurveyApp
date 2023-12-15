using AutoMapper;
using Domain.Models.Surveys;
using SurveyAppServer.ViewModels;

namespace SurveyAppServer.Profiles.Surveys;

public class UserManualViewModelToUserManual : Profile
{
    public UserManualViewModelToUserManual()
    {
        CreateMap<UserManualViewModel, UserManual>().ReverseMap();
    }
}