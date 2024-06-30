namespace Fire_Emblem;

public class SunTwinWing : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    
    public SunTwinWing(string name, string description) : base(name, description)
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
        return _owner.CurrentHP >= _owner.MaxHP * 0.25;
    }
    
    private void DoEffect()
    {
        _opponent.AddTemporaryPenalty("Spd", -5);
        _opponent.AddTemporaryPenalty("Def", -5);
        _opponent.NegationOfFollowUpGarantization = 1;
        _owner.NegationOfNegationOfFollowUp = 1;
    }
}