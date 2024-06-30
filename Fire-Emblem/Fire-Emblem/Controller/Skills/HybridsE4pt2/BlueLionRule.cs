namespace Fire_Emblem;

public class BlueLionRule : Skill
{
    private Character _owner;
    private Combat _combat;
    private Character _opponent;
    private double _damageAlteration;
    
    public BlueLionRule(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if(IsEligibleForEffect())
        {
            DoEffect();
        }

        if (IsOwnerDefender())
        {
            GuaranteeFollowUp();
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
        return _owner.GetEffectiveAttribute("Def") >= _opponent.GetEffectiveAttribute("Def");
    }
    
    private void DoEffect()
    {
        _damageAlteration = (_owner.GetEffectiveAttribute("Def") - _opponent.GetEffectiveAttribute("Def")) * 4;
        _damageAlteration = Math.Min(_damageAlteration, 40);
        _owner.AddTemporaryDamageAlteration("PercentageReduction", (int)_damageAlteration);
    }
    
    private bool IsOwnerDefender()
    {
        return _owner == _combat._defender;
    }
    
    private void GuaranteeFollowUp()
    {
        _owner.FollowUpGarantization += 1;
    }
}