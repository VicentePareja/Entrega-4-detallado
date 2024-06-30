namespace Fire_Emblem;

public class Scendscale : Skill
{
    private int _pushBonus;
    private double _atkPonderator = 0.25;
    public Scendscale(string name, string description) : base(name, description)
    {
        _pushBonus = 7;
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        owner.AddTemporaryDamageAlteration("ExtraDamage", owner.Atk * _atkPonderator);
        owner.pushBonus = _pushBonus;
        owner.SetPushActive();
    }
}