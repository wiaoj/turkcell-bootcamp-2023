// Open/Closed Principle: Bir nesne gelişime AÇIK değişime KAPALI olmalıdır.
Customer customer = new(
    "-,-",
    //CartType = new Gold(), // => gelitirmeye açık ve değişime kapalı oldu, orderManager classına müdahale etmeden istediğimiz kadar kart oluşturabiliyoruz.
    new Premium());

OrderManager orderManager = new(customer);

Decimal price = orderManager.GetDiscountedPrice(1000);
Console.WriteLine(price);


/* 
 * Senaryo: 
 */
//public enum CartType {
//    Standart,
//    Silver,
//    Gold,
//    Premium // sonradan eklendi
//}

public interface ICartType {
    public Decimal GetDiscounted(Decimal totalPrice);
}

public class Standart : ICartType {
    public Decimal GetDiscounted(Decimal totalPrice) {
        return totalPrice * .95M;
    }
}

public class Silver : ICartType {
    public Decimal GetDiscounted(Decimal totalPrice) {
        return totalPrice * .9M;
    }
}

public class Gold : ICartType {
    public Decimal GetDiscounted(Decimal totalPrice) {
        return totalPrice * .85M;
    }
}

public class Premium : ICartType {
    public Decimal GetDiscounted(Decimal totalPrice) {
        return totalPrice * .80M;
    }
}

public class Customer {
    public String Name { get; set; }
    public ICartType CartType { get; set; }
    public Customer(String name, ICartType cartType) {
        this.Name = name;
        this.CartType = cartType;
    }
}

public class OrderManager {
    public Customer Customer { get; set; }

    public OrderManager(Customer customer) {
        this.Customer = customer;
    }

    // Yanlış örnek
    public Decimal GetDiscountedPrice(Decimal total) {
        //return Customer.CartType switch {
        //    CartType.Standart => total * .95M,
        //    CartType.Silver => total * .9M,
        //    CartType.Gold => total * .85M,
        //    //CartType.Premium => tekrardan eklenir, kaldırılması gerekirse tekrardan siliniz vs,vs kötü mimari
        //    _ => total,
        //};
        return this.Customer.CartType.GetDiscounted(total);
    }
}