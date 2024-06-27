namespace Fire_Emblem;

public class Scendscale : Skill
{
    private int _pushBonus;
    public Scendscale(string name, string description) : base(name, description)
    {
        _pushBonus = 7;
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        int atk = owner.Atk;
        owner.AddTemporaryDamageAlteration("ExtraDamage", atk*0.25);
        owner.pushBonus = _pushBonus;
        owner.SetPushActive();
    }
}