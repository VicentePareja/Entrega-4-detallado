namespace Fire_Emblem;

public class SpdDefPush : Skill
{
    public SpdDefPush(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        int bonus = 7;
        if (owner.CurrentHP >= 0.25 * owner.MaxHP)
        {
            owner.AddTemporaryBonus("Spd", bonus);
            owner.AddTemporaryBonus("Def", bonus);
            owner.SetPushActive();
        }
    }
}