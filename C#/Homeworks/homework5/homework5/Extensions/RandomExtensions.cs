namespace homework5.Extensions;
public static class RandomExtensions {
    private static String[] names => "Taylak Şener,Rebihat Arslan Durmuş,Sıdkı Sakarya,Tüzenur Akça,Tasvir Sidar İhsanoğlu Manço,Bayan Büşranur Seçgül Bilge Demir,Meveddet Talibe İnönü İhsanoğlu,Sevcan Yılmaz,Gökperi Nurey Hançer,Muvahhide Çamurcuoğlu,Bayan Eriş Paksu Yılmaz Çamurcuoğlu,Ildız Gülen Arsoy,Zamir Duran,Bayan Dilcan Şahinder Çetin,Sebattin Aslan,Rojnu Ferinaz Ergül Çetin,Çağlar Ertaş,Merim Hayrioğlu,lSeniha Bilir Şener,Bağdaş Bilir,Fahrullah Korutürk,Ferihan Ülker,Möhsim Akçay,Özbilek Kısakürek,Fadıla Demir,Bayan Servinaz Lüfen Bilir,Almus Yaman,Nurbanu Demirel,Hanbiken Gülfeza Arsoy,Coşkun Çorlu".Split(' ', ',');

    public static String NextName(this Random random) {
        return names[random.Next(names.Length)];
    }
}