namespace Fire_Emblem;

public class SwiftStance : DamageAlterationSkill
{
    private int bonus;
    private int reduction;
    public SwiftStance(string name, string description) : base(name, description)
    {
        bonus = 6;
        reduction = 10;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;
        _counterTimes++;
        if (combat._attacker != owner && _counterTimes % 2 == 1)
        {
            owner.AddTemporaryBonus("Spd", bonus);
            owner.AddTemporaryBonus("Res", bonus);
        }
        
        if (combat._attacker != owner && _counterTimes % 2 == 0)
        {
            owner.MultiplyFollowUpDamageAlterations("PercentageReduction", reduction);
        }
    }
}