using System.Collections;

namespace BuiltInInterface;
public class Product : IComparable<Product> {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public Decimal Price { get; set; }
    public Int16 Stock { get; set; }

    public Int32 CompareTo(Product? other) {
        if(this.Price > other?.Price) {
            return 1;
        }

        return this.Price < other?.Price ? -1 : 0;
    }
}

public class ProductCollection : IEnumerable<Product> {
    private readonly List<Product> products = new();
    public void Add(Product product) {
        this.products.Add(product);
    }

    public void Clear() {
        this.products.Clear();
    }

    public List<Product> GetAll() {
        return this.products;
    }

    public IEnumerator<Product> GetEnumerator() {
        foreach(Product product in this.products) {
            yield return product;
        }
    }

    public void SortProducts() {
        this.products.Sort();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
    }
}