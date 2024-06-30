namespace Fire_Emblem;

public class AxeGuard : DamageAlterationSkill
{
    private Combat _combat;
    private Character _owner;
    private Character _opponent;
    private bool _isOpponentAxe;
    private double _damageReduction = -5.0;
    public AxeGuard(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        _counterTimes++;
        if (_counterTimes % 2 == 0)
        {
            SetAttributes(battle, owner);
            ApplyDamageEffect();
        }
    }
    private void SetAttributes(Battle battle, Character owner)
    {
        _combat = battle.CurrentCombat;
        _owner = owner;
        _opponent = (_combat._attacker == owner) ? _combat._defender : _combat._attacker;
        _isOpponentAxe = _opponent.Weapon == "Axe";
    }
    
    private void ApplyDamageEffect()
    {
        if (_isOpponentAxe)
        {
            _owner.AddTemporaryDamageAlteration("AbsoluteReduction", _damageReduction);
        }
       
    }
}