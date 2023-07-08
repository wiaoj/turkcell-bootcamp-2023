using Application.DataTransferObjects.Requests.Options;
using Application.DataTransferObjects.Responses.Options;
using AutoMapper;
using Domain.Entities.Answer;
using Domain.Entities.Survey;

namespace Application.Application.MappingProfiles;
internal sealed class OptionProfile : Profile {
    public OptionProfile() {
        CreateMap<CreateOptionRequest, OptionEntity>();
        CreateMap<OptionEntity, OptionDisplayResponse>();

        CreateMap<OptionEntity, OptionAnswerEntity>()
            .ForMember(
                destination => destination.Id,
                options => options.Ignore())
            .ForMember(
                destionation => destionation.OptionId,
                source => source.MapFrom(x => x.Id));
    }
}