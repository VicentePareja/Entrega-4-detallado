namespace Fire_Emblem;

public class BracingStance : DamageAlterationSkill
{
    private int bonus;
    public BracingStance(string name, string description) : base(name, description)
    {
        bonus = 6;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;
        _counterTimes++;
        if (combat._attacker != owner && _counterTimes % 2 == 1)
        {
            owner.AddTemporaryBonus("Def", bonus);
            owner.AddTemporaryBonus("Res", bonus);
        }
        
        if (combat._attacker != owner && _counterTimes % 2 == 0)
        {
            owner.MultiplyFollowUpDamageAlterations("PercentageReduction", 10);
        }
    }
}