namespace Fire_Emblem;

public class SteadyPosture : DamageAlterationSkill
{
    public SteadyPosture(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;
        _counterTimes++;
        if (combat._attacker != owner && _counterTimes % 2 == 1)
        {
            owner.AddTemporaryBonus("Spd", 6);
            owner.AddTemporaryBonus("Def", 6);
        }

        if (combat._attacker != owner && _counterTimes % 2 == 0)
        {
            owner.MultiplyFollowUpDamageAlterations("PercentageReduction", 10);
        }

    }
}