using System.Net.Http.Headers;

namespace Fire_Emblem;

public class Flare : Skill
{
    private Character _opponent;
    private Combat _combat;
    public Flare (string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (owner.GetWeaponType() == "Magic")
        {
            owner.AddHealingEachAttackPercentage(50);
            int penalty = (int)(0.2 * _opponent.Res);
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