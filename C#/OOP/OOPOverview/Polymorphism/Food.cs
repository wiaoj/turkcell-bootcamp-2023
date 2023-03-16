namespace Polymorphism;
public class Food {
    public String Name { get; set; }
    public virtual void OfferFood() {
        Console.WriteLine($"{Name}, pilav ile sunuldu.");
    }
}

public class Baklava : Food {
    public Baklava() {
        Name = "Baklava";
    }

    public override void OfferFood() {
        Console.WriteLine("Dondurma ile sunuldu.");
    }
}

public class KuruFasulye : Food {
    public KuruFasulye() {
        Name = "Kuru fasülye";
    }
}

public class Kofte: Food { }