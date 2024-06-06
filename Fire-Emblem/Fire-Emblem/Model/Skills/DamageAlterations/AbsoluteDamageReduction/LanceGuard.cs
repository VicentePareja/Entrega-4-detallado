namespace Fire_Emblem;

public class LanceGuard : DamageAlterationSkill
{
    private Combat _combat;
    private Character _owner;
    private Character _opponent;
    private bool _isOpponentLance;
    public LanceGuard(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        _counterTimes++;
        if (_counterTimes % 2 == 0)
        {
            SetAttributes(battle, owner);
            if (_isOpponentLance)
            {
                double damageReduction = -5.0;
                owner.AddTemporaryDamageAlteration("AbsoluteReduction", damageReduction);
            }
        }

    }

    private void SetAttributes(Battle battle, Character owner)
        {
            _combat = battle.CurrentCombat;
            _owner = owner;
            _opponent = (_combat._attacker == owner) ? _combat._defender : _combat._attacker;
            _isOpponentLance = _opponent.Weapon == "Lance";
        }
}