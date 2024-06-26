namespace Fire_Emblem;

public class MysticBoost : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private int _damageAfterCombat = -10;
    private int _penalty = -5;
    public MysticBoost(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        _opponent.AddTemporaryPenalty("Atk", _penalty);
        owner.AddDamageAfterCombat(_damageAfterCombat);
    }
    
    
    public void SetAttributes(Battle battle, Character owner)
    {
        _owner = owner;
        _combat = battle.CurrentCombat;
        if (_owner == _combat._attacker)
        {
            _opponent = _combat._defender;
        }
        else
        {
            _opponent = _combat._attacker;
        }
    }
}