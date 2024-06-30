namespace Fire_Emblem;

public class BindingShield : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    
    public BindingShield(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if(IsEligibleForEffect())
        {
            DoEffect();
            if (IsEligibleForDisableCounterAttack())
            {
                DisableCounterAttack();
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
        return _owner.GetEffectiveAttribute("Spd") >= _opponent.GetEffectiveAttribute("Spd") + 5;
    }
    
    private void DoEffect()
    {
        _owner.FollowUpGarantization += 1;
        _opponent.FollowUpNegation += 1;
    }
    
    private bool IsEligibleForDisableCounterAttack()
    {
        return _owner == _combat._attacker;
    }
    
    private void DisableCounterAttack()
    {
        _opponent.DisableCounterAttack();
    }
}