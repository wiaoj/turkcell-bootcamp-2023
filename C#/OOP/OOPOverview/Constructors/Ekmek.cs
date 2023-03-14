namespace Constructors {
    public class Ekmek {
        public Int32 Adet { get; set; }
        public String Tur { get; set; }

        public Ekmek() : this("Somun Ekmek", 1) {
            // this ile alttaki constructor'ı çağırıyoruz
            //Adet = 1;
            //Tur = "Somun Ekmek";
        }

        public Ekmek(Int32 adet) : this("Somun Ekmek", adet) {
            //Adet = adet;
            //Tur = "Somun";
        }

        public Ekmek(String tur) : this(tur, 1) {
            //Adet = 1;
            //Tur = tur;
        }

        public Ekmek(String tur, Int32 adet) {
            Tur = tur;
            Adet = adet;
        }
    }
}