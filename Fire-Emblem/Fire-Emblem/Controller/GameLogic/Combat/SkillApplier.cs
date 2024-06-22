namespace Fire_Emblem;

public class SkillApplier
{
    private readonly Battle _battle;
    public SkillApplier(Battle battle)
    {
        _battle = battle;
    }
    
    public void ApplySkills(Character attacker, Character defender)
    {
        ApplyNonDamageAlterationSkills(attacker);
        ApplyNonDamageAlterationSkills(defender);
        ApplyDamageAlterationSkills(attacker);
        ApplyDamageAlterationSkills(defender);
    }
    
    private void ApplyNonDamageAlterationSkills(Character unit)
    {
        foreach (var skill in unit.Skills) {
            skill.ApplyEffect(_battle, unit);
        }
    }
    
    private void ApplyDamageAlterationSkills(Character unit)
    {
        foreach (var skill in unit.Skills) {
            if (skill.IsDamageAlteration)
            {
                skill.ApplyEffect(_battle, unit);
            }
        }
    }

    public void ApplyPushSkills(Character unit)
    {
        bool pushCondition = unit.GetPushSkills() && unit.GetHasAttacked();
        if (pushCondition)
        {
            unit.AddDamageAfterCombat(5);
        }
    }
}