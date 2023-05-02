using IntroduceEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroduceEFCore.Data;
public sealed class BookStoreDbContext : DbContext {

    //public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

    public BookStoreDbContext() { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Review> Reviews { get; set; }

    //Veritabanı nerede ve hangi opsiyonlarla
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        String connectionString = @"Server=localhost,1434;Database=bookStoreSampleDb; User Id=sa; Password=MssqlPassword1.;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(connectionString);
    }

    // nasıl oluşturulacak?
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired(true)
                  .HasMaxLength(250);

        modelBuilder.Entity<Book>().Property(b => b.Description).HasMaxLength(250);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Restrict);


        base.OnModelCreating(modelBuilder);
    }
}