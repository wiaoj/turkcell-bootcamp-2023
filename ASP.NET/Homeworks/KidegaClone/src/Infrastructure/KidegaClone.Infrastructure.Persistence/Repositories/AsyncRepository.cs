using KidegaClone.Application.Common;
using KidegaClone.Application.Common.Specification;
using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Requests;
using KidegaClone.Domain.Entities;
using KidegaClone.Infrastructure.Persistence.Context;
using KidegaClone.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace KidegaClone.Infrastructure.Persistence.Repositories;
internal abstract class AsyncRepository<TEntity> : IAsyncRepository<TEntity>
    where TEntity : Entity, new() {
    private KidegaCloneDbContext Context { get; }
    protected IQueryable<TEntity> EntityTable => this.Context.Set<TEntity>();

    protected AsyncRepository(KidegaCloneDbContext context) {
        this.Context = context;
    }

    public Task CreateAsync(TEntity entity) {
        return Task.FromResult(this.Context.AddAsync(entity));
    }

    public Task DeleteAsync(TEntity entity) {
        return Task.FromResult(this.Context.Remove(entity));
    }

    public Task<IQueryable<TEntity>> GetAllAsync() {
        return GetAllAsync(null);
    }

    public Task<IQueryable<TEntity>> GetAllAsync(IncludeSpecification<TEntity>? specification) {
        return Task.FromResult(this.EntityTable.AsNoTracking().ApplyInclude(specification));
    }

    public Task<IPaginate<TEntity>> GetAllPaginatedAsync(PaginationRequest paginationRequest) {
        return GetAllPaginatedAsync(paginationRequest, null);
    }

    public async Task<IPaginate<TEntity>> GetAllPaginatedAsync(
        PaginationRequest paginationRequest,
        IncludeSpecification<TEntity>? includeSpecification) {
        return await this.EntityTable.AsNoTracking()
            .ApplyInclude(includeSpecification)
            .ToPaginateAsync(paginationRequest);
    }

    public Task<TEntity?> GetByIdAsync(Guid id) {
        return this.EntityTable.FirstOrDefaultAsync(entity => entity.Id == id);
    }
    public Task<TEntity?> GetByIdAsync(Guid id, IncludeSpecification<TEntity>? includeSpecification) {
        return this.EntityTable.AsNoTracking()
             .ApplyOrderBy(null)
             .ApplyInclude(includeSpecification)
             .FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public Task<Int32> SaveChangesAsync() {
        return this.Context.SaveChangesAsync();
    }

    public Task UpdateAsync(TEntity entity) {
        return Task.FromResult(this.Context.Update(entity));
    }

}