String[] products = { "Ürün 1", "Ürün 2", "Ürün 3" };

Array.Resize(ref products, products.Length + 1); // Array boyutu arttırılıyor

List<String> productList = new() {
    "Ürün 1",
    "Ürün 2",
    "Ürün 3",
};

List<String> shoppingCart = new();
//productList.ForEach(shoppingCart.Add);

foreach(String product in productList) {
    //product = "A"; -> readonly olduğu için değiştirilemez
    shoppingCart.Add(product);
    //productList.Remove(product); -> foreach içerisinde eleman silinemiyor
}

foreach(String item in shoppingCart) {
    productList.Remove(item);
}
