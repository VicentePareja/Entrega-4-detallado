namespace Fire_Emblem;

public class NewDivinity : Skill
{
    private Character _owner;
    private Combat _combat;
    private Character _opponent;
    private int _atkPenaly = -5;
    private int _resPenalty = -5;
    private double _hpThreshold = 0.25;
    private double _superHpThreshold = 0.4;
    private int _maxReduction = 40;
    private int _resPonderator = 4;
    
    public NewDivinity(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if(IsOwnerHealthy())
        {
            DoPenalties();
            if (HasOwnerMoreRes())
            {
                ApplyDamageAlteration();
            }
        }
        if (IsOwnerSuperHealthy())
        {
            NegateFollowUp();
        }
        
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = _owner == _combat._attacker ? _combat._defender : _combat._attacker;
    }
    
    private bool IsOwnerHealthy()
    {
        return _owner.CurrentHP >= _owner.MaxHP * _hpThreshold;
    }
    
    private void DoPenalties()
    {
        _opponent.AddTemporaryPenalty("Atk", _atkPenaly);
        _opponent.AddTemporaryPenalty("Res", _resPenalty);
    }
    
    private bool HasOwnerMoreRes()
    {
        return _owner.GetEffectiveAttribute("Res") >= _opponent.GetEffectiveAttribute("Res");
    }
    
    private void ApplyDamageAlteration()
    {
        int reduction = (_owner.GetEffectiveAttribute("Res") - _opponent.GetEffectiveAttribute("Res")) * _resPonderator;
        reduction = Math.Min(reduction, _maxReduction);
        _owner.AddTemporaryDamageAlteration("PercentageReduction", reduction);
    }
    private bool IsOwnerSuperHealthy()
    {
        return _owner.CurrentHP >= _owner.MaxHP * _superHpThreshold;
    }
    
    private void NegateFollowUp()
    {
        _opponent.FollowUpNegation += 1;
    }
}