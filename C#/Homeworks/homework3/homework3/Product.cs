namespace homework3;

public class Product : Entity {
    private const Byte TITLE_MAX_LENGTH = Byte.MaxValue;
    private const UInt16 STOCK_MAX_COUNT = UInt16.MaxValue;

    public String Title { get; private set; }
    public UInt16 Stock { get; private set; }

    private Product(String title, UInt16 count) {
        this.CheckTitle(title);
        this.Title = title;

        this.CheckStockCount(count);
        this.Stock = count;
        Console.WriteLine($"{this.Id} - {this.Title} adlı ürün {this.Created} tarihinde eklendi!");
    }

    public static Product Create(String title, UInt16 count) {
        return new(title, count);
    }

    public void Add() {
        CheckStockCount(++this.Stock);
        Console.WriteLine($"{this.Title} adlı ürün stoğu güncellenmiştir! Yeni stok: {this.Stock}");
    }

    public void Add(UInt16 stock) {
        CheckStockCount(stock);
        this.Stock += stock;
        Console.WriteLine($"{this.Title} adlı ürün stoğu güncellenmiştir! Yeni stok: {this.Stock}");
    }

    public void Buy() {
        _ = this.Stock > 0
            ? this.Stock--
            : throw new Exception("Stokta ürün kalmadığı için mağaza kapanmıştır!");
        Console.WriteLine($"{this.Id} - {this.Title} adlı ürün satın alındı! Kalan stok: {this.Stock}");
    }

    private Product CheckTitle(String title) {
        if(title.Length > TITLE_MAX_LENGTH)
            throw new Exception($"Ürün ismi {TITLE_MAX_LENGTH} karakterden uzun olamaz!");
        return this;
    }

    private Product CheckStockCount(UInt16 count) {
        if(count >= STOCK_MAX_COUNT)
            throw new Exception($"Ürün stoğu {STOCK_MAX_COUNT}'dan fazla olamaz!");
        return this;
    }
}