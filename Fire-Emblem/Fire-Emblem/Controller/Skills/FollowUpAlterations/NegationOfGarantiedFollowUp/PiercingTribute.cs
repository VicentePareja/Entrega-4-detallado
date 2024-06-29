namespace Fire_Emblem;

public class PiercingTribute : Skill
{
    private Character _opponent;
    public PiercingTribute(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        _opponent.NegationOfFollowUpGarantization = 1;
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