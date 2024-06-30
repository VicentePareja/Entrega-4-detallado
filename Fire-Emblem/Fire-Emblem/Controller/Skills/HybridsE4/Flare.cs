using System.Net.Http.Headers;

namespace Fire_Emblem;

public class Flare : Skill
{
    private Character _opponent;
    private Combat _combat;
    private int _healing;
    private double _resPonderator;
    public Flare (string name, string description) : base(name, description)
    {
        _healing = 50;
        _resPonderator = 0.2;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (owner.GetWeaponType() == "Magic")
        {
            owner.AddHealingEachAttackPercentage(_healing);
            int penalty = (int)(_resPonderator * _opponent.Res);
            _opponent.AddTemporaryPenalty("Res", -penalty);
        }
    }

    private void SetAttributes(Battle battle, Character owner)
    {
        _combat = battle.CurrentCombat;
        if (owner == _combat._attacker)
        {
            _opponent = _combat._defender;
        }
        else
        {
            _opponent = _combat._attacker;
        }
    }
}