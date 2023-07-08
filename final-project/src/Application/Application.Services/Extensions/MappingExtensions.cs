using Application.DataTransferObjects;
using AutoMapper;

namespace Application.Services.Extensions;
public static class MappingExtensions {
    public static IMapper Mapper;

    public static IQueryable<TResponse> MapTo<TResponse>(this IQueryable<IEntity> entity) where TResponse : IResponse {
        return Mapper.ProjectTo<TResponse>(entity);
    }

    public static IEnumerable<TResponse> MapTo<TResponse>(this IEnumerable<IEntity> entities) where TResponse : class {
        return Mapper.Map<IEnumerable<TResponse>>(entities);
    } 

    public static TResponse MapTo<TResponse>(this IEntity entity) where TResponse : IResponse {
        return Mapper.Map<TResponse>(entity);
    }

    public static TResponse MapTo<TResponse>(this IRequest entity) where TResponse : IEntity {
        return Mapper.Map<TResponse>(entity);
    }

    public static TResponse MapTo<TResponse>(this IRequest entity, TResponse originalEntity) where TResponse : IEntity {
        return Mapper.Map<TResponse>(originalEntity);
    }
}