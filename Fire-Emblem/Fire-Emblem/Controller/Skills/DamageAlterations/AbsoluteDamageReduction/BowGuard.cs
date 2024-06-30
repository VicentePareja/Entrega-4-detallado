namespace Fire_Emblem;

public class BowGuard: DamageAlterationSkill
{
    private Combat _combat;
    private Character _owner;
    private Character _opponent;
    private bool _isOpponentBow;
    private double _damageReduction = -5.0;
    
    public BowGuard(string name, string description) : base(name, description)
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
            _isOpponentBow = _opponent.Weapon == "Bow";
        }
    
    private void ApplyDamageEffect()
    {
        if (_isOpponentBow)
        {
            _owner.AddTemporaryDamageAlteration("AbsoluteReduction", _damageReduction);
        }
    }
    
}
