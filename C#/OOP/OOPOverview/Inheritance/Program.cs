using CounterStrike;

Player player = new();

Ak47 ak47 = new() {
    Damage = 41
};
DesertEagle desertEagle = new();

player.Weapon = new Weapon {
    Name = "Ekmek Bıçağı",
    Damage = 5,
};
player.RightClick();

player.Weapon = desertEagle;
player.RightClick();
player.Attack();
player.Reload();

player.Weapon = ak47;
player.RightClick();
player.Attack();
player.Reload();
