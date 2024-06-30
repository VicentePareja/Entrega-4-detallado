namespace Fire_Emblem;

public class Fury : Skill 
{
    private int bonus = 4;
    private int damage = 8;

    public Fury(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        ApplyBonus(owner);
        owner.AddDamageAfterCombat(damage);
    }
    
    private void ApplyBonus(Character owner)
    {
        owner.AddTemporaryBonus("Atk", bonus);
        owner.AddTemporaryBonus("Spd", bonus);
        owner.AddTemporaryBonus("Def", bonus);
        owner.AddTemporaryBonus("Res", bonus);
    }
}