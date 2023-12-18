using Domain.Models.Questions;
using SurveyAppServer.ViewModels.Questions;

using AutoMapper;

namespace SurveyAppServer.Profiles.Questions;

public class BaseQuestionViewModelToBaseQuestion : Profile
{
    public BaseQuestionViewModelToBaseQuestion()
    {
        CreateMap<BaseQuestionViewModel, BaseQuestion>().ReverseMap();
    }
}