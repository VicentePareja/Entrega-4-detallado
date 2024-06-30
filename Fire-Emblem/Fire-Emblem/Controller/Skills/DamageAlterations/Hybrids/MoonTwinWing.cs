namespace Fire_Emblem;

public class MoonTwinWing : DamageAlterationSkill
{
    private int _penalty = -5;
    private double _healthThreshold = 0.25;
    private int _speedPonderator = 4;
    private int _maxPercentageReduction = 40;
    private Character _owner;
    private Combat _combat;
    private Character _opponent;
    public MoonTwinWing(string name, string description) : base(name, description) {}

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (IsDamageReduction())
        {
            ApplyDamageReductionBasedOnSpeedDifference();
        }

        if (IsSpeedPenaltyApplicable())
        {
            ApplySpeedPenaltiesIfNecessary();
        }

    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _counterTimes++;
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
    }
    
    private bool IsDamageReduction()
    {
        return _counterTimes % 2 == 0;
    }
    
    private void ApplyDamageReductionBasedOnSpeedDifference()
    {
        int speedDifference = _owner.GetEffectiveAttribute("Spd") - _opponent.GetEffectiveAttribute("Spd");
        if (speedDifference > 0)
        {
            int damageReductionPercentage = CalculateDamageReductionPercentage(speedDifference);
            _owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
        }
    }
    
    private bool IsSpeedPenaltyApplicable()
    {
        return _counterTimes % 2 == 1;
    }
    
    private void ApplySpeedPenaltiesIfNecessary()
    {
        if (IsHealthAboveQuarter())
        {
            _opponent.AddTemporaryPenalty("Atk", _penalty);
            _opponent.AddTemporaryPenalty("Spd", _penalty);
        }
    }
    
    private int CalculateDamageReductionPercentage(int speedDifference)
    {
        int damageReductionPercentage = speedDifference * _speedPonderator;
        return Math.Min(damageReductionPercentage, _maxPercentageReduction);
    }
    private bool IsHealthAboveQuarter()
    {
        return Math.Round((double)_owner.CurrentHP / _owner.MaxHP, 9) >= _healthThreshold;
    }
}
