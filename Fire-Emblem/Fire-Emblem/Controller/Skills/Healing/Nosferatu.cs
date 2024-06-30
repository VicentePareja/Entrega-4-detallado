namespace Fire_Emblem;

public class Nosferatu : Skill
{
    private int hpGain;
    public Nosferatu(string name, string description) : base(name, description)
    {
        hpGain = 50;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        if (owner.GetWeaponType() == "Magic")
        {
            owner.AddHealingEachAttackPercentage(hpGain);
        }
    }
}