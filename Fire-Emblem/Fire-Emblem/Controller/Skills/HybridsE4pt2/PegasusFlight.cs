namespace Fire_Emblem;

public class PegasusFlight : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private int _penalty = -4;
    private int _spdDifference;
    private double _resPonderator;
    private int _maxPenalty = 8;
    
    public PegasusFlight(string name, string description) : base(name, description)
    {
        _spdDifference = 10;
        _resPonderator = 0.8;
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        _opponent.AddTemporaryPenalty("Atk", _penalty);
        _opponent.AddTemporaryPenalty("Def", _penalty);
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
        double penalty = CalculatePenalty();
        _opponent.AddTemporaryPenalty("Atk", - (int)penalty);
        _opponent.AddTemporaryPenalty("Def", - (int)penalty);
        if (IsSpdResOwnerBigger())
        {
            _opponent.FollowUpNegation += 1;
        }
    }
    
    private double CalculatePenalty()
    {
        double penalty = (_owner.Res - _opponent.Res) * _resPonderator;
        if (penalty >= 0)
        {
            penalty = Math.Min(penalty, _maxPenalty);
        }
        else
        {
            penalty = 0;
        }
        
        return penalty;
    }
    
    private bool IsSpdResOwnerBigger()
    {
        int spdResOwner = _owner.GetEffectiveAttribute("Spd") + _owner.GetEffectiveAttribute("Res");
        int spdResOpponent = _opponent.GetEffectiveAttribute("Spd") + _opponent.GetEffectiveAttribute("Res");
        return spdResOwner > spdResOpponent;
    }
}