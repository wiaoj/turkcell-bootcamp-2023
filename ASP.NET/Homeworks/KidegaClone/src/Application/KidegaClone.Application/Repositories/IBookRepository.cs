using KidegaClone.Application.Common;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Repositories;
public interface IBookRepository : IAsyncRepository<BookEntity> {
    Task<BookEntity?> GetByIdWithAuthorAsync(Guid id);
}