// See https://aka.ms/new-console-template for more information
using Polymorphism;

Console.WriteLine("Hello, World!");

KuruFasulye kuruFasulye = new() {

};
kuruFasulye.OfferFood();

Baklava baklava = new();
baklava.OfferFood();

/*
 * Food baklava = new Baklava();
 * baklava.OfferFood(); // not working
 * ((Baklava)baklava).OfferFood(); // working
 */

Console.WriteLine("Aşçı aldık, çalışmaya hazır!");
Chef chef = new();

chef.Cook(baklava); //Baklava, pilav ile sunuldu. çıktısını veriyor
// new anahtar sözcüğü ile kullanınca böyle oluyor
// virtual ve override etseydik baklavanın offerFood kısmını çalıştıracaktı

// spesifik olarak tek bir nesne üzerinden bu metodu çağıracak olursak new kullanılabilir
