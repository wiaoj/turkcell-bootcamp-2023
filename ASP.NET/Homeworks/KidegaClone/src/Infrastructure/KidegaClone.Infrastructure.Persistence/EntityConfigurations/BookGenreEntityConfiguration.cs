using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Infrastructure.Persistence.EntityConfigurations;
internal class BookGenreEntityConfiguration : IEntityTypeConfiguration<BookGenre> {
    public void Configure(EntityTypeBuilder<BookGenre> builder) {
        builder.ToTable("books_genres");

        builder.HasKey(x => x.BookId);
        builder.HasKey(x => x.GenreId);
    }
}