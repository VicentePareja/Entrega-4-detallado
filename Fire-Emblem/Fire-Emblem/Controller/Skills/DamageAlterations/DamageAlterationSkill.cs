namespace Fire_Emblem;

public abstract class DamageAlterationSkill : Skill
{
    protected int _counterTimes;
    protected DamageAlterationSkill(string name, string description) : base(name, description)
    {
        IsDamageAlteration = true;
        _counterTimes = 0;
    }
    
}