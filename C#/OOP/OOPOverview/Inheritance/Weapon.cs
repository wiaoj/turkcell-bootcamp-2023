namespace CounterStrike;
public class Weapon {
    public String Name { get; set; }
    public Int32 Range { get; set; }
    public Int32 Damage { get; set; } = 5; // Default value
    public Int32 Weight { get; set; }

    public void Attack() {
        // Varsayılan bıçak kabul edildi
        Console.WriteLine($"Düşmana {Name} silahıyla saldırılıyor, {Damage} hasar verildi.");
    }

    public virtual void PrepareToAttack() {
        Console.WriteLine("Bıçağı dik konuma getir.");
    }
}
public class Gun : Weapon {
    public Int32 BulletCount { get; set; } = 8;
    public Int32 MaximumBulletCount { get; set; } = 8 * 4;
    public Double BounceRate { get; set; } = 0.1D;

    public virtual void Reload() {
        Console.WriteLine("Tabanca görüntüsü oynatıldı.");
    }
    public override void PrepareToAttack() {
        Console.WriteLine("Tabanca ile nişan alındı.");
    }
}
public class Pistol : Gun {
    public Boolean IsSilencer { get; set; }
}
public class DesertEagle : Pistol {
    public Int32 Count { get; set; }

    public DesertEagle() {
        Name = "Desert Eagle";
        Damage = 20;
    }
}
public class Rifle : Gun {
    public Boolean IsBinocular { get; set; }

    public override void Reload() {
        base.Reload();
        Console.WriteLine("Tüfek görüntüsü oynatıldı.");
    }

    public override void PrepareToAttack() {
        Console.WriteLine("Dürbünden bakarak nişan al.");
    }
}
public class Ak47 : Rifle {
    public Ak47() {
        Name = "Ak 47";
        Damage = 40;
    }
}