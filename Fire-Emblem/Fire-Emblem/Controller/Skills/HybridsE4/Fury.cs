namespace Fire_Emblem;

public class Fury : Skill 
{
    private int bonus = 4;

    public Fury(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        owner.AddTemporaryBonus("Atk", bonus);
        owner.AddTemporaryBonus("Spd", bonus);
        owner.AddTemporaryBonus("Def", bonus);
        owner.AddTemporaryBonus("Res", bonus);
        
        owner.AddDamageAfterCombat(8);
    }
}