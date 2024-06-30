namespace Fire_Emblem;

public class SavvyFighter : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private int _percentageReduction = 30;
    private int _spdThreshold = 5;
    public SavvyFighter(string name, string description) : base(name, description)
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
        return _owner == _combat._defender;
    }
    
    private void DoEffect()
    {
        _opponent.NegationOfFollowUpGarantization = 1;
        _owner.NegationOfNegationOfFollowUp = 1;
        if (IsEligibleForSecondEffect())
        {
            _owner.AddFirstAttackDamageAlteration("PercentageReduction", _percentageReduction);
        }
    }
    
    private bool IsEligibleForSecondEffect()
    {
        return _owner.GetEffectiveAttribute("Spd") >= _opponent.GetEffectiveAttribute("Spd") - _spdThreshold;
    }
}