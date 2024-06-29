namespace Fire_Emblem;

public class PegasusFlight : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    
    public PegasusFlight(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        _opponent.AddTemporaryPenalty("Atk", -4);
        _opponent.AddTemporaryPenalty("Def", -4);
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
        bool isFast = _owner.Spd >= _opponent.Spd - 10;
        return isFast;
    }
    
    private void DoEffect()
    {
        double penalty = CalculatePenalty();
        _opponent.AddTemporaryPenalty("Atk", - (int)penalty);
        _opponent.AddTemporaryPenalty("Def", - (int)penalty);
        if (IsEligibleForSeccondEffect())
        {
            _opponent.FollowUpNegation += 1;
        }
    }
    
    private double CalculatePenalty()
    {
        double penalty = (_owner.Res - _opponent.Res) * 0.8;
        if (penalty >= 0)
        {
            penalty = Math.Min(penalty, 8);
        }
        else
        {
            penalty = 0;
        }
        
        return penalty;
    }
    
    private bool IsEligibleForSeccondEffect()
    {
        return _owner.Spd + _owner.Res > _opponent.Spd + _opponent.Res;
    }
}