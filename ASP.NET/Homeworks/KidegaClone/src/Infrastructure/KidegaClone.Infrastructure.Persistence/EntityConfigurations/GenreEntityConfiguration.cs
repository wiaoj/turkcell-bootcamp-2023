using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Infrastructure.Persistence.EntityConfigurations;
internal class GenreEntityConfiguration : IEntityTypeConfiguration<GenreEntity> {
    public void Configure(EntityTypeBuilder<GenreEntity> builder) {
        builder.ToTable("genres");

        builder.HasKey(genre => genre.Id);
        builder.HasIndex(genre => genre.Id).IsUnique();

        builder.Property(genre => genre.Id)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

        builder.Property(genre => genre.Name)
                .HasMaxLength(50)
                .IsRequired(true);

        builder.HasMany(genre => genre.Books)
                .WithMany(book => book.Genres)
                .UsingEntity<BookGenre>();

        IEnumerable<GenreEntity> genres = new List<GenreEntity>(){
            new() {
                Id = Guid.NewGuid(),
                Name = "Edebiyat"
            },
            new() {
                Id = Guid.NewGuid(),
                Name = "Türk Edebiyatı"
            },
            new() {
                Id = Guid.NewGuid(),
                Name = "Modern Türk Edebiyatı"
            }
        };


        builder.HasData(genres);
    }
}