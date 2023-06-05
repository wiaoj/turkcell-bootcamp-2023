using KidegaClone.Application.Repositories;
using KidegaClone.Domain.Entities;
using KidegaClone.Infrastructure.Persistence.Context;

namespace KidegaClone.Infrastructure.Persistence.Repositories;
internal sealed class GenreRepository : AsyncRepository<GenreEntity>, IGenreRepository {
    public GenreRepository(KidegaCloneDbContext context) : base(context) { }
}