namespace Fire_Emblem;

public class BlackEagleRule : Skill
{
    
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private double _healthThreshold = 0.25;
    private int _percentageReduction = 80;
    
    public BlackEagleRule(string name, string description): base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if(IsEligibleForEffect())
        {
            DoEffect();
            if (IsEligibleForSecondEffect())
            {
                DoSecondEffect();
            }
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
        return _owner.CurrentHP >= _owner.MaxHP * _healthThreshold;
    }
    
    private void DoEffect()
    {
        _owner.FollowUpGarantization += 1;
        
    }
    
    private bool IsEligibleForSecondEffect()
    {
        return _owner == _combat._defender;
    }
    
    private void DoSecondEffect()
    {
        _owner.AddFollowUpDamageAlteration("PercentageReduction", _percentageReduction);
    }
}