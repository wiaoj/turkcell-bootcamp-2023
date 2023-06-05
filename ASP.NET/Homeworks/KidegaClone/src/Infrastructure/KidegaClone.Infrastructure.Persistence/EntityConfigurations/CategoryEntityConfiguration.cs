using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Infrastructure.Persistence.EntityConfigurations;
internal class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity> {
    public void Configure(EntityTypeBuilder<CategoryEntity> builder) {
        builder.ToTable("categories");

        builder.HasKey(category => category.Id);
        builder.HasIndex(category => category.Id).IsUnique();

        builder.Property(category => category.Id)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

        builder.Property(category => category.Name)
                .HasMaxLength(50)
                .IsRequired(true);

        builder.HasMany(category => category.Books)
                .WithOne(book => book.Category)
                .HasForeignKey(book => book.CategoryId);
    }
}