using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Infrastructure.Persistence.EntityConfigurations;
internal class BookEntityConfiguration : IEntityTypeConfiguration<BookEntity> {
    public void Configure(EntityTypeBuilder<BookEntity> builder) {
        builder.ToTable("books");

        builder.HasKey(book => book.Id);
        builder.HasIndex(book => book.Id).IsUnique();

        builder.Property(book => book.Id)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

        builder.Property(book => book.Title)
                .HasMaxLength(250)
                .IsRequired(true);

        builder.Property(book => book.Barcode)
                .HasColumnType("nvarchar")
                .HasMaxLength(13);

        builder.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);

        builder.HasOne(book => book.Category)
                .WithMany(category => category.Books)
                .HasForeignKey(book => book.CategoryId);

        builder.HasMany(book => book.Genres)
                .WithMany(genre => genre.Books)
                .UsingEntity<BookGenre>();

        IEnumerable<BookEntity> books = new List<BookEntity>() {
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407150",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 2",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407151",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 3",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407152",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407150",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 2",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407151",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 3",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407152",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407150",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 2",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407151",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 3",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407152",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407150",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 2",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407151",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 3",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407152",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },new() {
                Id = Guid.NewGuid(),
                Title = "Book title",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407150",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 2",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407151",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 3",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407152",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407150",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 2",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407151",
                AuthorId = AuthorEntityConfiguration.AuthorId
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "Book title 3",
                Price = 120M,
                ImageUrl = "https://loremflickr.com/300/400",
                Barcode = "9786257407152",
                AuthorId = AuthorEntityConfiguration.AuthorId
            }
        };

        builder.HasData(books);
    }
}