namespace InterfaceSegregation;
/// <summary>
/// IRepository; bir varlığı, bir veri deposu ile olan ilişkilerini düzenler.
/// Kaynak veri deposu, Excel, Db, API gibi her şey olabilir.
/// </summary>
/// <typeparam name="Type"></typeparam>
public interface IRepository<Type> {
    public Type Get(Int32 id);
    public IEnumerable<Type> GetAll();
    public void Add(Type entity);
    public void Update(Type entity);
    public void Delete(Int32 id);
}

public class Product {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public Decimal Price { get; set; }
}

public class Category {
    public Int32 Id { get; set; }
    public String Name { get; set; }
}

public interface IProductRepository : IRepository<Product> {
    public IEnumerable<Product> GetProductsByName(String name);
}

public class ProductRepository : IProductRepository {
    public void Add(Product entity) {
        throw new NotImplementedException();
    }

    public void Delete(Int32 id) {
        throw new NotImplementedException();
    }

    public Product Get(Int32 id) {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAll() {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetProductsByName(String name) {
        throw new NotImplementedException();
    }

    public void Update(Product entity) {
        throw new NotImplementedException();
    }
}

public class CategoryRepository : IRepository<Category> {
    public void Add(Category entity) {
        throw new NotImplementedException();
    }

    public void Delete(Int32 id) {
        throw new NotImplementedException();
    }

    public Category Get(Int32 id) {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetAll() {
        throw new NotImplementedException();
    }

    public void Update(Category entity) {
        throw new NotImplementedException();
    }
}
