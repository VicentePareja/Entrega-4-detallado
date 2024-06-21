namespace Fire_Emblem;

public class Hliðskjálf : Skill
{
    Combat _combat;
    Character _opponent;
    Character _owner;
    
    public Hliðskjálf(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (IsEffect())
        {
            _opponent.DisableCounterAttack();
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _combat = battle.CurrentCombat;
        _owner = owner;
        if (owner == _combat._attacker)
        {
            _opponent = _combat._defender;
        }else
        {
            _opponent = _combat._attacker;
        }
    }
    
    private bool IsEffect()
    {
        bool IsOwnerAttacker = _owner == _combat._attacker;
        bool IsOwnerMage = _owner.GetWeaponType() == "Magic";
        bool IsOpponentMage = _opponent.GetWeaponType() == "Magic";

        return IsOwnerAttacker && IsOwnerMage && IsOpponentMage;
    }
}