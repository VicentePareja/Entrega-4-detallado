namespace Fire_Emblem;

public class BrashAssault : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    private double _weaponTriangleBonus;
    private string _advantage;
    private int _damage;
    private double _extraDamage;
    private double _absoluteReduction;
    private double _reduction;
    private Character _attacker;
    private Character _defender;
    
    public BrashAssault(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if(IsEligibleForEffect())
        {
            DoEffect();
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _owner = owner;
        _combat = battle.CurrentCombat;
        _opponent = _owner == _combat._attacker ? _combat._defender : _combat._attacker;
        _weaponTriangleBonus = 1;
    }
    
    private bool IsEligibleForEffect()
    {
        bool firstOption = (_owner.CurrentHP <= _owner.MaxHP * 0.99 && _owner == _combat._attacker);
        bool secondOption = (_opponent.CurrentHP == _opponent.MaxHP && _owner == _combat._attacker);
        return firstOption || secondOption;
    }
    
    private void DoEffect()
    {
        _opponent.AddTemporaryPenalty("Def", -4);
        _opponent.AddTemporaryPenalty("Res", -4);
        _owner.AddFirstAttackDamageAlteration("PercentageReduction", 30);
        _owner.FollowUpGarantization += 1;
        int extraDamage = CalculateDamage();
        _owner.AddFollowUpDamageAlteration("ExtraDamage", extraDamage);
    }
    
    private int CalculateDamage()
    {   
        double initialDamage = (double)InitialDamage();
        double newDamage = initialDamage + Math.Floor(_extraDamage);
        double damageReduced = newDamage;
        damageReduced = Math.Round(damageReduced, 9);
        return Math.Max(Convert.ToInt32(Math.Floor(damageReduced)) + Convert.ToInt32(_absoluteReduction),0);
    }
    
    private int InitialDamage()
    {
        _weaponTriangleBonus = CalculateWeaponTriangleBonusForAttack("atacante");
        int attackerAtk = _owner.GetFollowUpAttribute("Atk");
        int defenderDef = _opponent.GetFollowUpAttribute(_owner.Weapon == "Magic" ? "Res" : "Def");
        return CalculateBaseDamageForAttack(attackerAtk, defenderDef);
    }
    
    private int CalculateBaseDamageForAttack(int attackerAtk, int defenderDef)
    {
        return Math.Max((int)(attackerAtk * _weaponTriangleBonus - defenderDef), 0);
    }
    
    private double CalculateWeaponTriangleBonusForAttack(string advantage)
    {
        return advantage switch
        {
            "atacante" => 1.2,
            "defensor" => 0.8,
            _ => 1.0,
        };
    }
}