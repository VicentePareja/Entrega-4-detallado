namespace Fire_Emblem;

public class Resonance : Skill
{
    private int _damageAfterCombat;
    private int _extraDamage;
    private int _hpThreshold;
    public Resonance(string name, string description) : base(name, description)
    {
        _damageAfterCombat = 1;
        _extraDamage = 3;
        _hpThreshold = 2;
    }
    public override void ApplyEffect(Battle battle, Character owner)
    {
        bool IsEffect = owner.GetWeaponType() == "Magic" && owner.CurrentHP >= _hpThreshold;
        if (IsEffect)
        {
            owner.AddDamageBeforeCombat(_damageAfterCombat);
            owner.AddTemporaryDamageAlteration("ExtraDamage", _extraDamage);
        }
    }
}