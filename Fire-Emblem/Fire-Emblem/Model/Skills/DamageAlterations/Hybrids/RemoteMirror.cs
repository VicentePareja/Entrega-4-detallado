namespace Fire_Emblem;

public class RemoteMirror : DamageAlterationSkill
{
    public RemoteMirror(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;
        _counterTimes++;

        if (combat._attacker == owner && _counterTimes % 2 == 1)
        {

            owner.AddTemporaryBonus("Atk", 7);
            owner.AddTemporaryBonus("Res", 10);
        }

        if (combat._attacker == owner && _counterTimes % 2 == 0)
        {
            owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", 30);
        }
    }
}