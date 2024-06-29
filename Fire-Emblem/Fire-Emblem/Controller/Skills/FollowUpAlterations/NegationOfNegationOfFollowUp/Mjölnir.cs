namespace Fire_Emblem;

public class Mjölnir : Skill
{
    public Mjölnir(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {

        owner.NegationOfNegationOfFollowUp = 1;
    }
}