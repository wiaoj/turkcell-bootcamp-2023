namespace Encapsulation;
public class Product {
    private Double price;

    public void SetPrice(Double value) {
        if(value > 0) {
            this.price = value;
            return;
        }

        throw new ArgumentException($"{value} değeri 0 dan büyük olmalıdır!");
    }

    public Double GetPrice() {
        return this.price;
    }

    private String name;
    public String Name {
        get { return this.name; }
        set { name = value; }
    }

    public Int32 Stock { get; set; }

    public Boolean IsInStock {
        get {
            return Stock > 0;
        }
        /*private set;*/
    }

    public Single Discount { get; set; }
}