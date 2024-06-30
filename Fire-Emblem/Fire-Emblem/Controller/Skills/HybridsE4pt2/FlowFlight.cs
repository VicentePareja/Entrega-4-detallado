namespace Fire_Emblem;

public class FlowFlight : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    
    public FlowFlight(string name, string description) : base(name, description)
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
        return _owner == _combat._attacker;
    }
    
    private void DoEffect()
    {
        _owner.NegationOfNegationOfFollowUp = 1;
        if (IsEligibleForSeccondEffect())
        {
            DoSecondEffect();
        }
    }
    
    private bool IsEligibleForSeccondEffect()
    {
        return _owner.GetEffectiveAttribute("Spd") >= _opponent.GetEffectiveAttribute("Spd") - 10;
    }
    
    private void DoSecondEffect()
    {
        double dmgAlteration = (_owner.GetEffectiveAttribute("Def") - _opponent.GetEffectiveAttribute("Def")) * 0.7;
        dmgAlteration = Math.Min(Math.Max(dmgAlteration, 0), 7);
        _owner.AddTemporaryDamageAlteration("ExtraDamage", (int)dmgAlteration);
        _owner.AddTemporaryDamageAlteration("AbsoluteReduction", -(int)dmgAlteration);
    }
}