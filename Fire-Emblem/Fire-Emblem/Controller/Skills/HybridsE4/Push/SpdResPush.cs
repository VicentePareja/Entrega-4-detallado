namespace Fire_Emblem;

public class SpdResPush : Skill
{
    public SpdResPush(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        int bonus = 7;
        if (owner.CurrentHP >= 0.25 * owner.MaxHP)
        {
            owner.AddTemporaryBonus("Spd", bonus);
            owner.AddTemporaryBonus("Res", bonus);
            owner.SetPushActive();
        }
    }
}