namespace Fire_Emblem;

public class FierceStance : DamageAlterationSkill
{
    private int bonus;
    private int reduction;
    public FierceStance(string name, string description) : base(name, description)
    {
        bonus = 8;
        reduction = 10;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;
        _counterTimes++;
        if (combat._attacker != owner && _counterTimes % 2 == 1)
        {
            owner.AddTemporaryBonus("Atk", bonus);
        }
        if (combat._attacker != owner && _counterTimes % 2 == 0)
        {
            owner.MultiplyFollowUpDamageAlterations("PercentageReduction", reduction);
        }
    }
}