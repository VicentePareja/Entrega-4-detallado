namespace Fire_Emblem;

public class Bravery : DamageAlterationSkill
{
    private double _extraDamage = 5.0;
    public Bravery(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        _counterTimes++;
        if (_counterTimes % 2 == 0)
        {
            owner.AddTemporaryDamageAlteration("ExtraDamage", _extraDamage);
        }
    }
}