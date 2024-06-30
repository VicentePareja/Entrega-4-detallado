namespace Fire_Emblem;

public class SunTwinWing : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private int _spdPenalty = -5;
    private int _defPenalty = -5;
    private double _hpThreshold = 0.25;
    
    public SunTwinWing(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if(IsEligibleForEffect())
        {
            DoEffect();
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = _owner == _combat._attacker ? _combat._defender : _combat._attacker;
    }
    
    private bool IsEligibleForEffect()
    {
        return _owner.CurrentHP >= _owner.MaxHP * _hpThreshold;
    }
    
    private void DoEffect()
    {
        _opponent.AddTemporaryPenalty("Spd", _spdPenalty);
        _opponent.AddTemporaryPenalty("Def", _defPenalty);
        _opponent.NegationOfFollowUpGarantization = 1;
        _owner.NegationOfNegationOfFollowUp = 1;
    }
}