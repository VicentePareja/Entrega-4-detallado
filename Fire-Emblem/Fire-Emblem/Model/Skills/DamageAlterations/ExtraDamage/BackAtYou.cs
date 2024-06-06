namespace Fire_Emblem;

public class BackAtYou : DamageAlterationSkill
{
    private Combat _combat;
    private Character _opponent;
    private Character _owner;
    private bool _isInitiatorOpponent;
    public BackAtYou(string name, string description) : base(name, description)
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
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = (_combat._attacker == owner) ? _combat._defender : _combat._attacker;
        _isInitiatorOpponent = _combat._attacker != owner;
    }
    
    private void ApplyDamageEffect()
    {
        if (_isInitiatorOpponent)
        {
            double lostHP = _owner.MaxHP - _owner.CurrentHP;
            double extraDamage = Math.Round(lostHP * 0.5, 9);
            _owner.AddTemporaryDamageAlteration("ExtraDamage", extraDamage);
        }
    }
}