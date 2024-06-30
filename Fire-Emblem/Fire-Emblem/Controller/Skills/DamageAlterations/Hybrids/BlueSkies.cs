namespace Fire_Emblem;

public class BlueSkies : DamageAlterationSkill
{
    private double _damageReduction;
    private double _extraDamage;
    private Character _owner;
    
    public BlueSkies(string name, string description) : base(name, description)
    {
        _damageReduction = -5.0;
        _extraDamage = 5.0;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(owner);
        
        if (IsDamageAlteration())
        {
            ApplyDamageAlterations();
        }
    }

    private void SetAttributes(Character owner)
    {
        _owner = owner;
        _counterTimes++;
    }
    private bool IsDamageAlteration()
    {
        return _counterTimes % 2 == 0;
    }
    
    private void ApplyDamageAlterations()
    {
        _owner.AddTemporaryDamageAlteration("AbsoluteReduction", _damageReduction);
        _owner.AddTemporaryDamageAlteration("ExtraDamage", _extraDamage);
    }
}