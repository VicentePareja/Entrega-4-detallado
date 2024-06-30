namespace Fire_Emblem;

public class NewDivinity : Skill
{
    private Character _owner;
    private Combat _combat;
    private Character _opponent;
    private int _atkPenaly = -5;
    private int _resPenalty = -5;
    
    public NewDivinity(string name, string description) : base(name, description)
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
        if (IsEligibleForThirdEffect())
        {
            DoThridEffect();
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
        return _owner.CurrentHP >= _owner.MaxHP * 0.25;
    }
    
    private void DoEffect()
    {
        _opponent.AddTemporaryPenalty("Atk", _atkPenaly);
        _opponent.AddTemporaryPenalty("Res", _resPenalty);
    }
    
    private bool IsEligibleForSecondEffect()
    {
        return _owner.GetEffectiveAttribute("Res") >= _opponent.GetEffectiveAttribute("Res");
    }
    
    private void DoSecondEffect()
    {
        int reduction = (_owner.GetEffectiveAttribute("Res") - _opponent.GetEffectiveAttribute("Res")) * 4;
        reduction = Math.Min(reduction, 40);
        _owner.AddTemporaryDamageAlteration("PercentageReduction", reduction);
    }
    private bool IsEligibleForThirdEffect()
    {
        return _owner.CurrentHP >= _owner.MaxHP * 0.4;
    }
    
    private void DoThridEffect()
    {
        _opponent.FollowUpNegation += 1;
    }
}