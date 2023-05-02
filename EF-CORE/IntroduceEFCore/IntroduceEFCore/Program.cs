using IntroduceEFCore.Data;
using IntroduceEFCore.Models;

BookStoreDbContext context = new();

Author author = new() {
    Name = "Jules",
    LastName = "Verne"
};

context.Authors.Add(author);
context.Books.Add(new() {
    Title = "Denizler Altında 20.000 Fersah",
    Description = "Açıklama",
    Authors = new List<Author>() { author }
});

context.SaveChanges();