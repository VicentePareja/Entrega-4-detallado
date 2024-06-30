namespace Fire_Emblem;

public class Windsweep : Skill {
    
    private Combat _combat;
    private Character _owner;
    private Character _opponent;
    public Windsweep(string name, string description) : base(name, description) {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);

    if (IsSwords(_owner, _opponent)) {
            _opponent.DisableCounterAttack();
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _combat = battle.CurrentCombat;
        _owner = owner;
        if (_owner == _combat._attacker)
        {
            _opponent = _combat._defender;
        }else
        {
            _opponent = _combat._attacker;
        }
    }

    private bool IsSwords(Character owner, Character opponent)
    {
        return owner.Weapon == "Sword" && opponent.Weapon == "Sword";
    }
}