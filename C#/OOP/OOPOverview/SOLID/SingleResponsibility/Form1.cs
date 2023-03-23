using System.Data.SqlClient;

namespace SingleResponsibility;
public partial class Form1 : Form {
    public Form1() {
        InitializeComponent();
    }

    // SRP: Her nesnenin "SADECE BÝR" sorumluluðu olmalýdýr.
    // 1. Bir nesnede deðiþiklik yapmak için, birden fazla sebebiniz varsa; bu prensip ihlal ediliyor demektir.
    // 2. Form1 bir insan olsaydý sorumluluðunu nasýl anlatýrdý?
    // Veriyi alýp iþleyip sonucu gösterdiði için connection açmak veritabanýna yazmak gibi iþlemler burada yapýlmaz!
    private void buttonAddProduct_Click(Object sender, EventArgs e) {
        ProductService productService = new();
        String name = textBoxName.Text;
        Decimal price = Decimal.Parse(textBoxPrice.Text);

        Int32 affectedRows = productService.AddProduct(name, price);

        String message = affectedRows > 0 ? "Baþarýlý" : "Ýþlem yapýlamadý";

        MessageBox.Show(message);
    }
}