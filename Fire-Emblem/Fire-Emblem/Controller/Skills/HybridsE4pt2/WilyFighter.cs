namespace Fire_Emblem;

public class WilyFighter : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private double _hpThreshold = 0.25;
    public WilyFighter(string name, string description) : base(name, description)
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
        return _owner.CurrentHP >= _owner.MaxHP * _hpThreshold && _owner == _combat._defender;
    }
    
    private void DoEffect()
    {
        _opponent.DisableAllBonuses();
        _owner.FollowUpGarantization += 1;
    }
}