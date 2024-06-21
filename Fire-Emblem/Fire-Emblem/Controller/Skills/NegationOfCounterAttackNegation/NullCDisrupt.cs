namespace Fire_Emblem;

public class NullCDisrupt : Skill
{
    public NullCDisrupt(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        owner.EnableNegationOfCounterAttackNegation();
    }
}