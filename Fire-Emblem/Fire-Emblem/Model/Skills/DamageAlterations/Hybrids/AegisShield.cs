namespace Fire_Emblem;

public class AegisShield : DamageAlterationSkill
{
    public AegisShield(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        _counterTimes++;
        if (_counterTimes % 2 == 1)
        {
            owner.AddTemporaryBonus("Def", 6);
            owner.AddTemporaryBonus("Res", 3);
        }
        
        if (_counterTimes % 2 == 0)
        {
            owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", 50);
        }
    }
}