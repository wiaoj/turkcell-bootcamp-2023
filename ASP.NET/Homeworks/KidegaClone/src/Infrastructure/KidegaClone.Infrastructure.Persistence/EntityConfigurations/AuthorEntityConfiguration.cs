using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Infrastructure.Persistence.EntityConfigurations;
internal class AuthorEntityConfiguration : IEntityTypeConfiguration<AuthorEntity> {
    internal static Guid AuthorId => Guid.Parse("79b113ae-0391-4521-8616-3b8ffa960eb8");
    public void Configure(EntityTypeBuilder<AuthorEntity> builder) {
        builder.ToTable("authors");

        builder.HasKey(author => author.Id);
        builder.HasIndex(author => author.Id).IsUnique();

        builder.Property(author => author.Id)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

        builder.Property(author => author.FirstName)
                .HasMaxLength(150)
                .IsRequired(true);

        builder.Property(author => author.LastName)
                .HasMaxLength(150)
                .IsRequired(true);

        builder.Property(author => author.FullName)
                .HasComputedColumnSql(
            $"CONCAT ([{nameof(AuthorEntity.FirstName)}], ' ', [{nameof(AuthorEntity.LastName)}])");

        builder.Property(author => author.Biography)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired(false);

        builder.Property(author => author.ImageUrl)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired(false);

        builder.HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .HasForeignKey(book => book.AuthorId);

        builder.HasData(new AuthorEntity() {
            Id = AuthorId,
            FirstName = "Yazar Adı",
            LastName = "Yazar Soyadı"
        }, new() {
            Id  = Guid.NewGuid(),
            FirstName = "Selahattin",
            LastName = "Çakıcı"
        });
    }
}