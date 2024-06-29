namespace Fire_Emblem;

public class WyvernFlight : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    
    public WyvernFlight(string name, string description) : base(name, description)
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
        double penalty = (_owner.Def - _opponent.Def) * 0.8;
        if (penalty >= 0)
        {
            penalty = Math.Min(penalty, 8);
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