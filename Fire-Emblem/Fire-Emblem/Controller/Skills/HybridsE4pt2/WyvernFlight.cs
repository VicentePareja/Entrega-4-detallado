namespace Fire_Emblem;

public class WyvernFlight : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private int _atkDefPenalty = -4;
    private int _spdDifference;
    private double _defPonderator = 0.8;
    private int _maxPenalty = 8;
    
    public WyvernFlight(string name, string description) : base(name, description)
    {
        _spdDifference = 10;
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        _opponent.AddTemporaryPenalty("Atk", _atkDefPenalty);
        _opponent.AddTemporaryPenalty("Def", _atkDefPenalty);
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
        bool isFast = _owner.Spd >= _opponent.Spd - _spdDifference;
        return isFast;
    }
    
    private void DoEffect()
    {
        int atkDefPenalty = CalculatePenalty();
        _opponent.AddTemporaryPenalty("Atk", - atkDefPenalty);
        _opponent.AddTemporaryPenalty("Def", - atkDefPenalty);
        
        if (IsEligibleForSeccondEffect())
        {
            _opponent.FollowUpNegation += 1;
        }
    }
    
    private int CalculatePenalty()
    {
        double penalty = (_owner.Def - _opponent.Def) * _defPonderator;
        if (penalty >= 0)
        {
            penalty = Math.Min(penalty, _maxPenalty);
        }
        else
        {
            penalty = 0;
        }
        
        return (int)penalty;
    }
    
    private bool IsEligibleForSeccondEffect()
    {
        int spdDefOwner = _owner.GetEffectiveAttribute("Spd") + _owner.GetEffectiveAttribute("Def");
        int spdDefOpponent = _opponent.GetEffectiveAttribute("Spd") + _opponent.GetEffectiveAttribute("Def");
        return spdDefOwner > spdDefOpponent;
    }
}