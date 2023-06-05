using AutoMapper;
using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Responses;

namespace KidegaClone.Application.MapProfiles;
internal class DefaultMappingProfile : Profile {
    public DefaultMappingProfile() {
        CreateMap(typeof(IPaginate<>), typeof(PaginationResponse<>));
    }
}