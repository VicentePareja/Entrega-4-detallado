namespace Fire_Emblem;

public class KestrelStance : DamageAlterationSkill
{
    private int bonus;
    private int reduction;
    private Combat _combat;
    private Character _owner;
    public KestrelStance(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);

        if (IsBonuses())
        {
            ApplyBonuses();
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
    
    private void ApplyBonuses()
    {
        _owner.AddTemporaryBonus("Atk", bonus);
        _owner.AddTemporaryBonus("Spd", bonus);
    }
    
    private bool IsDamageAlteration()
    {
        return _combat._attacker != _owner && _counterTimes % 2 == 0;
    }
}