namespace Fire_Emblem;

public class DragonsIre : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private readonly int _atkPenalty = -4;
    private readonly int _resPenalty = -4;
    
    public DragonsIre(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if(IsEligibleForEffect())
        {
            DoEffect();
            if (IsOwnerDefender())
            {
                NeutralizeFollowUpNegation();
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
        return _owner.CurrentHP >= _owner.MaxHP * 0.25;
    }
    
    private void DoEffect()
    {
        _opponent.AddTemporaryPenalty("Atk", _atkPenalty);
        _opponent.AddTemporaryPenalty("Res", _resPenalty);
        _owner.FollowUpGarantization += 1;
    }
    
    private bool IsOwnerDefender()
    {
        return _owner == _combat._defender;
    }
    
    private void NeutralizeFollowUpNegation()
    {
        _owner.NegationOfNegationOfFollowUp = 1;
    }
}