using KidegaClone.Application.DataTransferObjects.Pagination;

namespace KidegaClone.Application.DataTransferObjects.Responses;
public sealed record PaginationResponse<TEntity>(PaginationInfo PaginationInfo, IEnumerable<TEntity> Items)
    : IPaginate<TEntity> {
}