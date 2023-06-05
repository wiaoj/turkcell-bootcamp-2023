using KidegaClone.Application.Repositories;
using KidegaClone.Domain.Entities;
using KidegaClone.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace KidegaClone.Infrastructure.Persistence.Repositories;
internal sealed class BookRepository : AsyncRepository<BookEntity>, IBookRepository {
    public BookRepository(KidegaCloneDbContext context) : base(context) { }

    public Task<BookEntity?> GetByIdWithAuthorAsync(Guid id) {
        return this.EntityTable.FirstOrDefaultAsync(book => book.Id == id);
    }
}