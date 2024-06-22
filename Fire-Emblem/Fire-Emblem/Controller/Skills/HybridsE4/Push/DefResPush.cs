namespace Fire_Emblem;

public class DefResPush : Skill
{
    public DefResPush(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        int bonus = 7;
        if (owner.CurrentHP >= 0.25 * owner.MaxHP)
        {
            owner.AddTemporaryBonus("Def", bonus);
            owner.AddTemporaryBonus("Res", bonus);
            owner.SetPushActive();
        }
    }
}