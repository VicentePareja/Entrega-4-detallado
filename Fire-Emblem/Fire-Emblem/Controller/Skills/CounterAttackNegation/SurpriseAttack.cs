namespace Fire_Emblem;

public class SurpriseAttack : Skill
{
    private Combat _combat;
    private Character _opponent;
    private Character _owner;
    public SurpriseAttack(string name, string description) : base(name, description)
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
        if (_owner == _combat._attacker)
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
        bool IsOwnerArcher = _owner.GetWeaponType() == "Bow";
        bool IsOpponentArcher = _opponent.GetWeaponType() == "Bow";

        return IsOwnerAttacker && IsOwnerArcher && IsOpponentArcher;
    }
}