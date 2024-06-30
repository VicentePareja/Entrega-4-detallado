namespace Fire_Emblem;

public class PhysNullFollow : Skill{

    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private int _spdPenalty = -4;
    private int _defPenalty = -4;

    public PhysNullFollow(string name, string description): base(name, description) { }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        
        _opponent.AddTemporaryPenalty("Spd", _spdPenalty);
        _opponent.AddTemporaryPenalty("Def", _defPenalty);
        _owner.NegationOfNegationOfFollowUp = 1;
        _opponent.NegationOfFollowUpGarantization = 1;
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = _owner == _combat._attacker ? _combat._defender : _combat._attacker;
    }
    
    
}