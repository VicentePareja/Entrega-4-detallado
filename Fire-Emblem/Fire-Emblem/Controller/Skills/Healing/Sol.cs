namespace Fire_Emblem;

public class Sol : Skill
{
    public Sol(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        owner.AddHealingEachAttackPercentage(25);
    }
}