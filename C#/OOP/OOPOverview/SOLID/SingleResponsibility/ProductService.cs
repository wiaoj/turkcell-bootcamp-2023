namespace SingleResponsibility;
public class ProductService { // Ürün varlığıyla ilgili tüm işleri bu servis yapar
    public Int32 AddProduct(String name, Decimal price) {
        //Environment Values olmalı: Dışarıdan okunmalı
        String connectionString = "Connection String";
        String commandText = "INSERT INTO Products (ProductName, UnitPrice) values (@name, @price)";

        Dictionary<String, Object> parameters = new() {
            { "@name", name },
            { "@price", price }
        };

        DataAccess dataAccess = new(connectionString);

        Int32 affectedRows = dataAccess.ExecuteNonQuery(commandText, parameters);

        return affectedRows;
    }

    public Int32 UpdateProduct(String name, Decimal price) {
        return default;
    }

    public void SendInfoMailToProductOwner(String mail) { }

    //public void ChangeCustomerAddress() { } // ihlal
}