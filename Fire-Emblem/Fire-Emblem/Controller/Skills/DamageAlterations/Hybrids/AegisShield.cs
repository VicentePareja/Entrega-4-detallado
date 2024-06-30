namespace Fire_Emblem;

public class AegisShield : DamageAlterationSkill
{
    private Character _owner;
    private int _defBonus;
    private int _resBonus;
    private int _reductionPercentage;
    public AegisShield(string name, string description) : base(name, description)
    {
        _defBonus = 6;
        _resBonus = 3;
        _reductionPercentage = 50;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(owner);
        if (IsBonuses())
        {
            ApplyBonuses();
        }
        
        if (IsDamageAlteration())
        {
            owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", _reductionPercentage);
        }
    }
    
    private void SetAttributes(Character owner)
    {
        _owner = owner;
        _counterTimes++;
    }
    
    private bool IsBonuses()
    {
        return _counterTimes % 2 == 1;
    }
    
    private void ApplyBonuses()
    {
        _owner.AddTemporaryBonus("Def", _defBonus);
        _owner.AddTemporaryBonus("Res", _resBonus);
    }
    
    private bool IsDamageAlteration()
    {
        return _counterTimes % 2 == 0;
    }
}