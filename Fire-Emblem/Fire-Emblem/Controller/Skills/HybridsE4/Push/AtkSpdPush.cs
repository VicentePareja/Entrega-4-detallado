namespace Fire_Emblem;

public class AtkSpdPush : Skill
{
    public AtkSpdPush(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        int bonus = 7;
        if (owner.CurrentHP >= 0.25 * owner.MaxHP)
        {
            owner.AddTemporaryBonus("Atk", bonus);
            owner.AddTemporaryBonus("Spd", bonus);
            owner.SetPushActive();
        }
    }
}