using System.Data.SqlClient;

namespace SingleResponsibility;
public partial class Form1 : Form {
    public Form1() {
        InitializeComponent();
    }

    // SRP: Her nesnenin "SADECE B�R" sorumlulu�u olmal�d�r.
    // 1. Bir nesnede de�i�iklik yapmak i�in, birden fazla sebebiniz varsa; bu prensip ihlal ediliyor demektir.
    // 2. Form1 bir insan olsayd� sorumlulu�unu nas�l anlat�rd�?
    // Veriyi al�p i�leyip sonucu g�sterdi�i i�in connection a�mak veritaban�na yazmak gibi i�lemler burada yap�lmaz!
    private void buttonAddProduct_Click(Object sender, EventArgs e) {
        ProductService productService = new();
        String name = textBoxName.Text;
        Decimal price = Decimal.Parse(textBoxPrice.Text);

        Int32 affectedRows = productService.AddProduct(name, price);

        String message = affectedRows > 0 ? "Ba�ar�l�" : "��lem yap�lamad�";

        MessageBox.Show(message);
    }
}