using KidegaClone.Application.Repositories;
using KidegaClone.Domain.Entities;
using KidegaClone.Infrastructure.Persistence.Context;

namespace KidegaClone.Infrastructure.Persistence.Repositories;
internal sealed class AuthorRepository : AsyncRepository<AuthorEntity>, IAuthorRepository {
    public AuthorRepository(KidegaCloneDbContext context) : base(context) { }
}