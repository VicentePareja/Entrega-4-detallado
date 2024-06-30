namespace Fire_Emblem;

public class Sympathetic : DamageAlterationSkill
{
    private Combat _combat;
    private bool _isInitiatorOpponent;
    private bool _isOwnerHealthLow;
    private double _damageReduction = -5.0;
    public Sympathetic(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        _counterTimes++;
        if (_counterTimes % 2 == 0)
        {
            SetAttributes(battle, owner);
            if (_isInitiatorOpponent && _isOwnerHealthLow)
            {
                owner.AddTemporaryDamageAlteration("AbsoluteReduction", _damageReduction);
            }
        } 
    }
    private void SetAttributes(Battle battle, Character owner)
    {
        _combat = battle.CurrentCombat;
        _isInitiatorOpponent = _combat._attacker != owner;
        _isOwnerHealthLow = owner.CurrentHP <= owner.MaxHP * 0.5;
    }
}