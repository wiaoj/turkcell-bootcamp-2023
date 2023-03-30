namespace LinqIntro;
public class Product {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public Decimal Price { get; set; }
    public String Description { get; set; }
    public Int16 Stock { get; set; }

    public Category Category { get; set; }
}

public class Category {
    public Int32 Id { get; set; }
    public String Name { get; set; }
}

public class ProductService {
    private List<Product> products;
    private List<Category> categories;
    public ProductService() {
        this.categories = new() {
            new(){Id = 1, Name="Spor"},
            new(){Id = 2, Name="Giyim"},
            new(){Id = 3, Name="Kamp"},
        };

        this.products = new() {
            new() {
                Id = 1,
                Name = "Bisiklet",
                Description = "Spor amaçlı",
                Price = 3000M,
                Stock = 520,
                Category = this.categories[0],
            },
            new() {
                Id = 2,
                Name = "Dambıl Set",
                Description = "Spor amaçlı",
                Price = 3000M,
                Stock = 250,
                Category = this.categories[0],
            },
            new() {
                Id = 3,
                Name = "Şort",
                Description = "Giyim amaçlı",
                Price = 150M,
                Stock = 10,
                Category = this.categories[1],
            },
            new() {
                Id = 4,
                Name = "Tişört",
                Description = "Spor amaçlı",
                Price = 200M,
                Stock = 150,
                Category = this.categories[0],
            },
            new() {
                Id = 5,
                Name = "Çadır",
                Description = "Kampçılık amaçlı",
                Price = 5000M,
                Stock = 1850,
                Category = this.categories[2],
            },
            new() {
                Id = 6,
                Name = "Olta",
                Description = "Keyif amaçlı",
                Price = 500M,
                Stock = 150,
                Category = this.categories[2],
            },
            new() {
                Id = 7,
                Name = "Eldiven",
                Description = "Spor amaçlı",
                Price = 50M,
                Stock = 150,
                Category = this.categories[1],
            },
        };
    }

    public List<Product> GetProducts() => this.products;
    public List<Category> GetCategories() => this.categories;
}