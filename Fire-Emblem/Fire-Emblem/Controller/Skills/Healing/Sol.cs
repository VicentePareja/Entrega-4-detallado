namespace Fire_Emblem;

public class Sol : Skill
{
    private int healingPercentage = 25;
    public Sol(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        owner.AddHealingEachAttackPercentage(healingPercentage);
    }
}