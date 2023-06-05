using AutoMapper;
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.MapProfiles;
internal sealed class AuthorMappingProfile : Profile{
    public AuthorMappingProfile() {
        CreateMap<AuthorEntity, AuthorSelectionResponse>();

        CreateMap<AuthorEntity, UpdateBookDetailAuthor>();
    }
}