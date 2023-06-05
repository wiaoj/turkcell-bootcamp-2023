using KidegaClone.Application.Common.Specification;
using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Requests;
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KidegaClone.Infrastructure.Persistence.Extensions;
internal static class IQueryableExtensions {
    public static IQueryable<TEntity> ApplyInclude<TEntity>(
        this IQueryable<TEntity> queryable,
        IncludeSpecification<TEntity>? includeSpecification) where TEntity : Entity, new() {
        return includeSpecification is null
                            ? queryable
                            : includeSpecification.Includes
                                .Aggregate(queryable, (current, include) => current.Include(include));

    }
    public static IQueryable<TEntity> ApplyOrderBy<TEntity>(
        this IQueryable<TEntity> queryable,
        OrderBySpecification<TEntity>? orderBySpecification) where TEntity : Entity, new() {
        return orderBySpecification is null
                            ? queryable.OrderBy(entity => entity.Id)
                            : orderBySpecification.Orders
                                .Aggregate(queryable, (order, orders) => order.OrderBy(orders));
    }

    public static async Task<IPaginate<TEntity>> ToPaginateAsync<TEntity>(this IQueryable<TEntity> source,
                                                           PaginationRequest paginationRequest) {
        Int32 pageStartIndex = (paginationRequest.Page - 1) * paginationRequest.Size;

        IQueryable<TEntity> items = source.Skip(pageStartIndex).Take(paginationRequest.Size);

        Int64 count = await source.LongCountAsync().ConfigureAwait(false);

        PaginationInfo paginationInfo = new(paginationRequest.Page, paginationRequest.Size, count);

        return new PaginationResponse<TEntity>(paginationInfo, items);
    }
}