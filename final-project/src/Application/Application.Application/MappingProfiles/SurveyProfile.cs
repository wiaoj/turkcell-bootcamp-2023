using AutoMapper;
using Domain.Entities.Survey;

namespace Application.Application.MappingProfiles;
internal sealed class SurveyProfile : Profile {
    public SurveyProfile() {
        CreateMap<CreateSurveyRequest, SurveyEntity>();
        CreateMap<SurveyEntity, SurveyDisplayResponse>();
    }
}