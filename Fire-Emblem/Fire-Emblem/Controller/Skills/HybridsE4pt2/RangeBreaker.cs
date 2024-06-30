namespace Fire_Emblem;

public class RangeBreaker : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private double _hpThreshold = 0.5;
    public RangeBreaker(string name, string description) : base(name, description)
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
        bool isHealthy = _owner.CurrentHP >= _owner.MaxHP * _hpThreshold;
        string weaponType = _opponent.GetWeaponType();
        bool isOpponentRange = weaponType == "Magic" || weaponType == "Bow";
        return isHealthy && isOpponentRange;
    }
    
    private void DoEffect()
    {
        _owner.FollowUpGarantization += 1;
        _opponent.FollowUpNegation += 1;
    }
}