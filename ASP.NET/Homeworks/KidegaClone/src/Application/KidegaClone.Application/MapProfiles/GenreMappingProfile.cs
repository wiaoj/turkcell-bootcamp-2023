using AutoMapper;
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.MapProfiles;
internal class GenreMappingProfile : Profile{
    public GenreMappingProfile() {
        CreateMap<GenreEntity, GenreSelectionResponse>();

        CreateMap<GenreEntity, UpdateBookDetailGenre>();
    }
}