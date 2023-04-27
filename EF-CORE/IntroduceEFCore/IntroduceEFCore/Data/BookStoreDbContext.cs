using IntroduceEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroduceEFCore.Data;
public sealed class BookStoreDbContext : DbContext {
    private const String Connection_String = "";

    public BookStoreDbContext(DbContextOptions options) : base(options) { }


    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    // Veritabanı nerede ve hangi opsiyonlarla
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(Connection_String);
    }

    // nasıl oluşturulacak?
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
    }
}