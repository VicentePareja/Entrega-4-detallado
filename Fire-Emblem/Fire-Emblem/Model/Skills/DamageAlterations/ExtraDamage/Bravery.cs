namespace Fire_Emblem;

public class Bravery : DamageAlterationSkill
{
    public Bravery(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        _counterTimes++;
        if (_counterTimes % 2 == 0)
        {
            double extraDamage = 5.0;
            owner.AddTemporaryDamageAlteration("ExtraDamage", extraDamage);
        }
    }
}