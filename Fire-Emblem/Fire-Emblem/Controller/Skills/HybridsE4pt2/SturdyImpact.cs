namespace Fire_Emblem;

public class SturdyImpact : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private const int _defBonus = 10;
    private const int _atkBonus = 6;
    public SturdyImpact(string name, string description) : base(name, description)
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
        _owner.AddTemporaryBonus("Def", _defBonus);
        _owner.AddTemporaryBonus("Atk", _atkBonus);
        _opponent.FollowUpNegation += 1;
    }
}