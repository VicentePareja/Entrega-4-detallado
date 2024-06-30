namespace Fire_Emblem;

public class DartingStance : DamageAlterationSkill
{
    private int bonus;
    private int reduction;
    private Combat _combat;
    private Character _owner;
    public DartingStance(string name, string description) : base(name, description)
    {
        bonus = 8;
        reduction = 10;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (IsBonuses())
        {
            owner.AddTemporaryBonus("Spd", bonus);
        }

        if (IsDamageAlteration())
        {
            owner.MultiplyFollowUpDamageAlterations("PercentageReduction", reduction);
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _combat = battle.CurrentCombat;
        _owner = owner;
        _counterTimes++;
    }
    
    private bool IsBonuses()
    {
        return _combat._attacker != _owner && _counterTimes % 2 == 1;
    }
    
    private bool IsDamageAlteration()
    {
        return _combat._attacker != _owner && _counterTimes % 2 == 0;
    }
}