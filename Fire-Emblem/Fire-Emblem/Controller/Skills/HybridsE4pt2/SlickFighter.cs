namespace Fire_Emblem;

public class SlickFighter : Skill
{
    private Character _owner;
    private Combat _combat;
    private double _hpThreshold = 0.25;
    public SlickFighter(string name, string description) : base(name, description)
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
    }
    
    private bool IsEligibleForEffect()
    {
        return _owner.CurrentHP >= _owner.MaxHP * _hpThreshold && _owner == _combat._defender;
    }
    
    private void DoEffect()
    {
        _owner.DisableAllPenalties();
        _owner.FollowUpGarantization += 1;
    }
}