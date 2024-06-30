namespace Fire_Emblem;

public class BracingStance : DamageAlterationSkill
{
    private int bonus;
    private Combat _combat;
    private Character _owner;
    public BracingStance(string name, string description) : base(name, description)
    {
        bonus = 6;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        _counterTimes++;
        if (IsBonuses())
        {
            ApplyBonuses();
        }
        if (IsDamageAlteration())
        {
            owner.MultiplyFollowUpDamageAlterations("PercentageReduction", 10);
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _combat = battle.CurrentCombat;
        _owner = owner;
    }

    private bool IsBonuses()
    {
        return _combat._attacker != _owner && _counterTimes % 2 == 1;
    }
    
    private void ApplyBonuses()
    {
        _owner.AddTemporaryBonus("Def", bonus);
        _owner.AddTemporaryBonus("Res", bonus);
    }
    
    private bool IsDamageAlteration()
    {
        return _combat._attacker != _owner && _counterTimes % 2 == 0;
    }
}