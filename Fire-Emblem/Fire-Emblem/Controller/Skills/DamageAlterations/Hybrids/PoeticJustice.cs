namespace Fire_Emblem;

public class PoeticJustice : DamageAlterationSkill
{
    private Combat _combat;
    private Character _opponent;
    private Character _owner;
    private double _extraDamage;
    private double _damagePonderator = 0.15;
    private int _penalty = -4;
    
    public PoeticJustice(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        
        if (IsDamageAlteration())
        {
            owner.AddTemporaryDamageAlteration("ExtraDamage", _extraDamage);
        }
        if (IsPenaltyApplicable())
        {
            _opponent.AddTemporaryPenalty("Spd", _penalty);
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _counterTimes++;
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
        _extraDamage = (double)_opponent.GetEffectiveAttribute("Atk") * _damagePonderator;
    }
    
    private bool IsDamageAlteration()
    {
        return _counterTimes % 2 == 0;
    }
    
    private bool IsPenaltyApplicable()
    {
        return _counterTimes % 2 == 1;
    }
}