using AutoMapper;
using Domain.Models.Users;
using SurveyAppServer.ViewModels.Users;

namespace SurveyAppServer.Profiles.Users;

public class UserViewModelToUser : Profile
{
    public UserViewModelToUser()
    {
        CreateMap<UserViewModel, User>().ReverseMap();
    }
}