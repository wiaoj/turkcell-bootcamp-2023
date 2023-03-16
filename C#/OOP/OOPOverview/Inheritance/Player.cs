namespace CounterStrike;
public class Player {
    public String Name { get; set; }
    public String Icon { get; set; }
    public Weapon Weapon { get; set; }

    public void Attack() {
        Weapon.Attack();
    }

    public void Reload() {
        if(Weapon is Gun gun) {
            gun.Reload();
        }
    }

    public void RightClick() {
        Weapon.PrepareToAttack();
    }
}