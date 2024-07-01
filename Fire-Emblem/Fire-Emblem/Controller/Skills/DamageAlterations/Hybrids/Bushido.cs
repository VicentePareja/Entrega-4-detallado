namespace Fire_Emblem;

public class Bushido : DamageAlterationSkill
{
    private double _extraDamage = 7.0;
    private Combat _combat;
    private Character _owner;
    private Character _opponent;
    private int _maxDamageReduction = 40;
    private int _speedPonderator = 4;
    public Bushido(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAtributes(battle, owner);
        
        if (IsDamageAlteration())
        {
            owner.AddTemporaryDamageAlteration("ExtraDamage", _extraDamage);
            ApplySpeedBasedDamageReduction();
        }
    }
    private void SetAtributes(Battle battle, Character owner)
    {
        _counterTimes++;
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
    }
    
    private bool IsDamageAlteration()
    {
        return _counterTimes % 2 == 0;
    }
    private void ApplySpeedBasedDamageReduction()
    {
        int speedDifference = _owner.GetEffectiveAttribute("Spd") - _opponent.GetEffectiveAttribute("Spd");
        if (speedDifference > 0)
        {
            int damageReductionPercentage = speedDifference * _speedPonderator;
            damageReductionPercentage = Math.Min(damageReductionPercentage, _maxDamageReduction);
            _owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
        }
    }
}