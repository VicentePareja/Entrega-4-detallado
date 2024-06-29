namespace Fire_Emblem;

public class WaryFighter : Skill
{
    private Character _opponent;
    
    public WaryFighter(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (owner.CurrentHP >= owner.MaxHP * 0.5)
        {
            owner.FollowUpNegation += 1;
            _opponent.FollowUpNegation += 1;
        }
    }


    private void SetAttributes(Battle battle, Character owner)
    {
        if (battle.CurrentCombat._attacker == owner)
        {
            _opponent = battle.CurrentCombat._defender;
        }
        else
        {
            _opponent = battle.CurrentCombat._attacker;
        }
    }
    
}