namespace Fire_Emblem;

public class Windsweep : Skill {
    
    public Windsweep(string name, string description) : base(name, description) {
    }
    
    public override void ApplyEffect(Battle battle, Character owner) {
        Combat combat = battle.CurrentCombat;
        Character opponent;
        if (owner == combat._attacker) {
            opponent = combat._defender;
        }else {
            opponent = combat._attacker;
        }
        
        if (IsSwords(owner, opponent)) {
            opponent.DisableCounterAttack();
        }
    }

    private bool IsSwords(Character owner, Character opponent)
    {
        return owner.Weapon == "Sword" && opponent.Weapon == "Sword";
    }
}