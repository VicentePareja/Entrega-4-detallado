namespace Fire_Emblem;
public class ArmoredBlow : BlowSkill {
    private int Bonus { get; set; }

    public ArmoredBlow(string name, string description) : base(name, description) {
        Bonus = 8; 
    }

    protected override void ApplySpecificEffect(Character owner) {
        owner.AddTemporaryBonus("Def", Bonus);
    }
}