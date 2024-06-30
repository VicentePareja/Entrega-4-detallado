namespace Fire_Emblem;

public class SteadyPosture : DamageAlterationSkill
{
    private int _counterTimes = 0;
    private int _spdBonus = 6;
    private int _defBonus = 6;
    private int _percentageReduction = 10;
    private Combat _combat;
    private Character _owner;
    public SteadyPosture(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (IsBonusApplicable())
        {
            ApplyBonus();
        }
        if (IsDamageAlteration())
        {
            ApplyDamageAlterations();
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _counterTimes++;
        _owner = owner;
        _combat = battle.CurrentCombat;
    }
    
    private bool IsBonusApplicable()
    {
        return _combat._attacker != _owner && _counterTimes % 2 == 1;
    }
    
    private void ApplyBonus()
    {
        _owner.AddTemporaryBonus("Spd", _spdBonus);
        _owner.AddTemporaryBonus("Def", _defBonus);
    }
    
    private bool IsDamageAlteration()
    {
        return _combat._attacker != _owner && _counterTimes % 2 == 0;
    }
    
    private void ApplyDamageAlterations()
    {
        _owner.MultiplyFollowUpDamageAlterations("PercentageReduction", _percentageReduction);
    }
}