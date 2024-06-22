namespace Fire_Emblem;

public class SolarBrace:Skill
{
    public SolarBrace(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        Character attacker = battle.CurrentCombat._attacker;
        if (owner == attacker)
        {
            owner.AddHealingEachAttackPercentage(50);
        }
    }
}