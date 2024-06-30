namespace Fire_Emblem;

public class EclipseBrace : Skill
{
    private Combat _combat;
    private Character _opponent;
    private bool _isAttacker;
    private Character _owner;
    private int _healing;
    private double _defPonderator;
    public EclipseBrace(string name, string description) : base(name, description)
    {
        _healing = 50;
        _defPonderator = 0.3;
    }
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);

        if (_isAttacker)
        {
            DoEffect();
        }
    }

    public void SetAttributes(Battle battle, Character character)
    {
        _combat = battle.CurrentCombat;
        _owner = character;
        if (character == _combat._attacker)
        {
            _opponent = _combat._defender;
        }
        else
        {
            _opponent = _combat._attacker;
        }
        _isAttacker = _owner == _combat._attacker;
    }
    private void DoEffect()
    {
        double extraDamage = _defPonderator * _opponent.GetEffectiveAttribute("Def");
        if(_owner.GetWeaponType() != "Magic")
        {
            _owner.AddTemporaryDamageAlteration("ExtraDamage", extraDamage);
        }
        _owner.AddHealingEachAttackPercentage(_healing);
    }
}