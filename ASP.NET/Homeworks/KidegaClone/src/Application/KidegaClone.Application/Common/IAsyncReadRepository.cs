using KidegaClone.Application.Common.Specification;
using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Requests;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Common;
public interface IAsyncReadRepository<TEntity> where TEntity : Entity, new() {
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetAllAsync(IncludeSpecification<TEntity>? includeSpecification);
    Task<IPaginate<TEntity>> GetAllPaginatedAsync(PaginationRequest paginationRequest);
    Task<IPaginate<TEntity>> GetAllPaginatedAsync(PaginationRequest paginationRequest, IncludeSpecification<TEntity>? includeSpecification);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity?> GetByIdAsync(Guid id, IncludeSpecification<TEntity>? includeSpecification);
}