using AutoMapper;
using KidegaClone.Application.DataTransferObjects;
using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Extensions;
public static class MappingExtensions {
    public static IMapper Mapper;

    public static IQueryable<TResponse> MapTo<TResponse>(this IQueryable<Entity> entity) where TResponse : IResponse {
        return Mapper.ProjectTo<TResponse>(entity);
    }

    public static IPaginate<TResponse> MapToPaginate<TEntity, TResponse>(this IPaginate<TEntity> paginatedEntities)
        where TResponse : IResponse 
        where TEntity : Entity {
        return Mapper.Map<PaginationResponse<TResponse>>(paginatedEntities);
    }

    public static IEnumerable<TResponse> MapTo<TResponse>(this IEnumerable<Entity> entities) where TResponse : IResponse {
        return Mapper.Map<IEnumerable<TResponse>>(entities);
    }

    public static TResponse MapTo<TResponse>(this Entity entity) where TResponse : IResponse {
        return Mapper.Map<TResponse>(entity);
    }

    public static TResponse MapTo<TResponse>(this IRequest entity) where TResponse : Entity {
        return Mapper.Map<TResponse>(entity);
    }

    public static TResponse MapTo<TResponse>(this IRequest entity, TResponse originalEntity) where TResponse : Entity {
        return Mapper.Map<TResponse>(originalEntity);
    }
}