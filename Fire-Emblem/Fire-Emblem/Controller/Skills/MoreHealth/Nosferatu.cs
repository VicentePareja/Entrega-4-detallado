namespace Fire_Emblem;

public class Nosferatu : Skill
{
    public Nosferatu(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        if (owner.GetWeaponType() == "Magic")
        {
            owner.AddHealingEachAttackPercentage(50);
        }
    }
}