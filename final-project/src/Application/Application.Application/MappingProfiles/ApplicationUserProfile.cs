using AutoMapper;
using Domain.Entities;

namespace Application.Application.MappingProfiles;
internal sealed class ApplicationUserProfile : Profile {
    public ApplicationUserProfile() {
        CreateMap<RegisterRequest, ApplicationUser>();
    }
}