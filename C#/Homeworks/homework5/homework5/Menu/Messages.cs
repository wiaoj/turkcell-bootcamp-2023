using homework5.Entities.Base;

namespace homework5.Menu;
public class Messages {
    public static String EntityAddIsSuccess(Entity entity) {
        return $"{entity} eklenmiştir.";
    }

    public static String EntityDeleteIsSuccess(Object @object) {
        return $"{@object} silinmiştir.";
    }

    public static String EntityUpdateIsSuccess(Entity entity) {
        return $"{entity} güncellenmiştir.";
    }

    public static String ProcessWaiting => "İşlem bekleniyor: ";

    public class Root {
        public const String Title = "Ana Menü";
        public const String FirstInfo = "' ' boşluk tuşu ile ana menüye dönebilirsiniz.";
        public const String SecondInfo = "Önceki menüye dönmek için <- (geri) tuşunu kullanınız.";
        public const String ThirdInfo = "Uygulamadan çıkmak için ESC tuşuna basınız.";
    }


    public class Student {
        public const String Title = "1 - Öğrenci Menüsü";
        public const String OperationTitle = "1.1 - Öğrenci işlemleri";
        public const String ListTitle = "1.2 - Öğrencileri listele";
        public const String SearchTitle = "1.3 - Öğrenciler arasında ara";

        public const String Name = "Öğrenci ismi: ";
        public const String NameIsEmpty = "Öğrenci ismi boş olamaz";

        public const String LastName = "Öğrenci soyadı: ";
        public const String LastNameIsEmpty = "Öğrenci soyadı boş olamaz";

        public const String AddMenuTitle = "1.1.1 - Öğrenci ekle";
        public const String DeleteMenuTitle = "1.1.2 - Öğrenci sil";

        public const String ListMenuTitle = "1.2.1 - Öğrencileri listele";
        public const String ListSearchMenuTitle = "1.2.2 - Öğrenci isim ve soyisim'e göre listele";
        public const String ListedTitle = "Öğrenciler listeleniyor...";

        public const String GetId = "Aranacak öğrenci kodu: ";
        public const String DeleteId = "Silinecek öğrenci kodu: ";
        public const String IdIsEmpty = "Öğrenci kodu boş olamaz";


        public const String NameLastName = "Aramak istediğiniz öğrenci adını giriniz: ";
        public const String NameLastNameIsEmpty = "Öğrenci isim - soyisim boş olamaz";

        public const String SearchByIdFirstInfo = "Öğrenci kodu (id)'nun tamamını veya bir kısmını girerek öğrenci arayabilirsiniz.";
        public const String SearchByIdTitle = "1.3.1 - Öğrenci kodu (id) ile ara";


        public const String SearchByNameLastNameFirstInfo = "Öğrenci isim soyisminin tamamını veya bir kısmını girerek";
        public const String SearchByNameLastNameSecondInfo = "ilgili isim ve soyisimlere sahip öğrencileri görebilirsiniz. (Onaylamak için enter tuşuna basınız)";
        public const String SearchByNameLastNameThirdInfo = "Eğer öğrenci kodu (id) değerini biliyorsanız onunla işlem yapmanızı tavsiye ederiz.";
        public const String SearchByNameLastNameTitle = "1.3.2 - Öğrenci isim ve soyisim ile ara";
    }

    public class Teacher {
        public const String Title = "2 - Eğitmen Menüsü";
        public const String OperationTitle = "2.1 - Eğitmen işlemleri";
        public const String ListTitle = "2.2 - Eğitmenleri listele";
        public const String SearchTitle = "2.3 - Eğitmenler arasında ara";

        public const String Name = "Eğitmen ismi: ";
        public const String NameIsEmpty = "Eğitmen ismi boş olamaz";

        public const String LastName = "Eğitmen soyadı: ";
        public const String LastNameIsEmpty = "Eğitmen soyadı boş olamaz";

        public const String AddMenuTitle = "2.1.1 - Eğitmen ekle";

        public const String ListMenuTitle = "2.2.1 - Eğitmenleri listele";
        public const String ListSearchMenuTitle = "2.2.2 - Eğitmen isim ve soyisim'e göre listele";
        public const String ListedTitle = "Eğitmenler listeleniyor...";

        public const String GetId = "Aranacak eğitmen kodu: ";
        public const String IdIsEmpty = "Eğitmen kodu boş olamaz";

        public const String NameLastName = "Aramak istediğiniz eğitmen adını giriniz: ";
        public const String NameLastNameIsEmpty = "Eğitmen isim - soyisim boş olamaz";

        public const String SearchByIdFirstInfo = "Eğitmen kodu (id)'nun tamamını veya bir kısmını girerek eğitmen arayabilirsiniz.";
        public const String SearchByIdTitle = "2.3.1 - Eğitmen kodu (id) ile ara";


        public const String SearchByNameLastNameFirstInfo = "Eğitmen isim soyisminin tamamını veya bir kısmını girerek";
        public const String SearchByNameLastNameSecondInfo = "ilgili isim ve soyisimlere sahip eğitmenleri görebilirsiniz. (Onaylamak için enter tuşuna basınız)";
        public const String SearchByNameLastNameThirdInfo = "Eğer eğitmen kodu (id) değerini biliyorsanız onunla işlem yapmanızı tavsiye ederiz.";
        public const String SearchByNameLastNameTitle = "2.3.2 - Eğitmen isim ve soyisim ile ara";
    }

    public class Class {
        public const String Title = "3 - Sınıf Menüsü";
        public const String OperationTitle = "3.1 - Sınıf işlemleri";
        public const String ListTitle = "3.2 - Sınıfları listele";
        public const String SearchTitle = "3.3 - Sınıflar arasında ara";

        public const String Name = "Sınıf ismi: ";
        public const String NameIsEmpty = "Sınıf ismi boş olamaz";

        public const String AddMenuTitle = "3.1.1 - Sınıf ekle";
        public const String AddMenuFirstInfo = "Eklenecek sınıfa bir tane öğretmen atanması gerekiyor.";
        public const String AddMenuSecondInfo = "Önce ilgili öğretmen kodunu bulunuz.";
        public const String AddMenuThirdInfo = "' '(boşluk) => 2 => 3 => 2 tuşlarıyla ulaşabilirsiniz";

        public const String ListMenuTitle = "3.2.1 - Sınıfları listele";
        public const String ListSearchMenuTitle = "3.2.2 - Sınıfları isime göre listele";
        public const String ListedTitle = "Sınıflar listeleniyor...";

        public const String GetId = "Aranacak sınıf kodu: ";
        public const String IdIsEmpty = "Sınıf kodu boş olamaz";

        public const String SearchName = "Aramak istediğiniz sınıf adını giriniz: ";

        public const String SearchByIdFirstInfo = "Sınıf kodu (id)'nun tamamını veya bir kısmını girerek sınıf arayabilirsiniz.";
        public const String SearchByIdTitle = "3.3.1 - Sınıf kodu (id) ile ara";


        public const String SearchByNameFirstInfo = "Sınıf isminin tamamını veya bir kısmını girerek";
        public const String SearchByNameSecondInfo = "eşleşen sınıfları görebilirsiniz. (Onaylamak için enter tuşuna basınız)";
        public const String SearchByNameThirdInfo = "Eğer sınıf kodu (id) değerini biliyorsanız onunla işlem yapmanızı tavsiye edarız.";
        public const String SearchByNameTitle = "3.3.2 - Sınıf ismi ile ara";

        public const String TeacherId = "Oluşturulacak sınıfın sorumlu öğretmen kodu (id): ";
        public const String TeacherIdIsEmpty = "Sorumlu öğretmen kodu boş olamaz";
    }

    public class Homework {
        public const String Title = "4 - Ödev Menüsü";
        public const String OperationTitle = "4.1 - Ödev işlemleri";
        public const String AddMenuTitle = "4.1.1 - Ödev ekle";

        public const String Name = "Ödev ismi: ";
        public const String NameIsEmpty = "Ödev ismi boş olamaz";

        public const String Description = "Ödev açıklaması: ";
        public const String DescriptionIsEmpty = "Ödev açıklaması boş olamaz";
    }
}