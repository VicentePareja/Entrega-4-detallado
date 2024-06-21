namespace Fire_Emblem;

public class LunarBrace : DamageAlterationSkill
{
    private Combat _combat;
    private Character _opponent;
    private Character _owner;
    private bool _isOwnerInitiator;
    private bool _isPhysicalAttack;
    public LunarBrace(string name, string description) : base(name, description) {}

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        _counterTimes++;
        if (_counterTimes % 2 == 0)
        {
            ApplyDamageEffect();
        }

        
    }
    
    private void SetAttributes(Battle battle, Character owner) 
    {
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = (_combat._attacker == owner) ? _combat._defender : _combat._attacker;
        _isOwnerInitiator = _combat._attacker == owner;
        _isPhysicalAttack = owner.Weapon != "Magic";
    }
    
    private void ApplyDamageEffect() 
    {
        if (IsEffectApplicable(_isOwnerInitiator, _isPhysicalAttack))
        {
            Character opponent = _combat._defender;
            double extraDamage = opponent.GetEffectiveAttribute("Def") * 0.3;
            _owner.AddTemporaryDamageAlteration("ExtraDamage", extraDamage);
        }
    }
    
    private bool IsEffectApplicable(bool isOwnerInitiator, bool isPhysicalAttack)
    {
        return isOwnerInitiator && isPhysicalAttack;
    }
    
}