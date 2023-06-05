using KidegaClone.Application.Common;
using KidegaClone.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace KidegaClone.Infrastructure.Persistence.Context;
internal class KidegaCloneDbContext : IdentityDbContext<UserEntity, IdentityRole, String> {
    private readonly IDateTimeProvider dateTimeProvider;

    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookGenre> BookGenre { get; set; }

    public KidegaCloneDbContext(DbContextOptions<KidegaCloneDbContext> options,
                                IDateTimeProvider dateTimeProvider) : base(options) {
        this.dateTimeProvider = dateTimeProvider;
    }

    public override Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default) {
        IEnumerable<EntityEntry<Entity>> datas = this.ChangeTracker.Entries<Entity>();

        foreach(EntityEntry<Entity> data in datas) {
            _ = data.State switch {
                EntityState.Added => data.Entity.CreatedAt = this.dateTimeProvider.UtcNow,
                EntityState.Modified => data.Entity.UpdatedAt = this.dateTimeProvider.UtcNow,
                _ => this.dateTimeProvider.UtcNow,
            };
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}