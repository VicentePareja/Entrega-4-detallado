namespace Fire_Emblem;

public class AtkDefPush : Skill
{
    public AtkDefPush(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        int bonus = 7;
        if (owner.CurrentHP >= 0.25 * owner.MaxHP)
        {
            owner.AddTemporaryBonus("Atk", bonus);
            owner.AddTemporaryBonus("Def", bonus);
            owner.SetPushActive();
        }
    }
}