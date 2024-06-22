namespace Fire_Emblem;

public class EclipseBrace : Skill
{
    private Combat _combat;
    private Character _opponent;
    public EclipseBrace(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        bool isAttacker = owner == _combat._attacker;

        if (isAttacker)
        {
            double extraDamage = 0.3 * _opponent.GetEffectiveAttribute("Def");
            owner.AddTemporaryDamageAlteration("ExtraDamage", extraDamage);
            owner.AddHealingEachAttackPercentage(50);
        }
    }

    public void SetAttributes(Battle battle, Character character)
    {
        _combat = battle.CurrentCombat;
        if (character == _combat._attacker)
        {
            _opponent = _combat._defender;
        }
        else
        {
            _opponent = _combat._attacker;
        }
    }
}