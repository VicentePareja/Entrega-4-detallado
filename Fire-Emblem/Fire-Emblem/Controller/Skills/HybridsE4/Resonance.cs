namespace Fire_Emblem;

public class Resonance : Skill
{
    public Resonance(string name, string description) : base(name, description)
    {
    }
    public override void ApplyEffect(Battle battle, Character owner)
    {
        bool IsEffect = owner.GetWeaponType() == "Magic" && owner.CurrentHP >= 2;
        if (IsEffect)
        {
            owner.CurrentHP -= 1;
            owner.AddTemporaryDamageAlteration("ExtraDamage", 3);
        }
    }
}