namespace Fire_Emblem;

public class RemoteSturdy : DamageAlterationSkill
{
    public RemoteSturdy(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;
        _counterTimes++;

        if (combat._attacker == owner && _counterTimes % 2 == 1)
        {
            owner.AddTemporaryBonus("Atk", 7);
            owner.AddTemporaryBonus("Def", 10);
        }

        if (combat._attacker == owner && _counterTimes % 2 == 0)
        {
            owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", 30);
        }

    }
}