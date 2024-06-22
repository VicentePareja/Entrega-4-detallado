namespace Fire_Emblem;

public class PlayerSkillCleaner
{
    
    public void ClearSkills(Character unit)
    {
        ClearTemporaryBonuses(unit);
        ClearTemporaryPenalties(unit);
        CleanTemporaryDamageAlterations(unit);
        ReEnableAttacks(unit);
        CleanHealings(unit);
        CleanNonCombatDamage(unit);
    }
    private void ClearTemporaryBonuses(Character unit)
    {
        unit.CleanBonuses();
        unit.CleanFirstAttackBonuses();
        unit.CleanFollowUpBonuses();
        unit.ReEnableBonuses();
    }

    private void ClearTemporaryPenalties(Character unit)
    {
        unit.CleanPenalties();
        unit.CleanFirstAttackPenalties();
        unit.CleanFollowUpPenalties();
        unit.ReEnablePenalties();
    }

    private void CleanTemporaryDamageAlterations(Character unit)
    {
        unit.CleanFirstAttackDamageAlterations();
        unit.CleanTemporaryDamageAlterations();
        unit.CleanFollowUpDamageAlterations();
    }

    private void ReEnableAttacks(Character unit)
    {
        unit.ReEnableCounterAttack();
        unit.DisableNegationOfCounterAttackNegation();
    }
    
    private void CleanHealings(Character unit)
    {
        unit.ResetHealingEachAttackPercentage();
    }
    
    private void CleanNonCombatDamage(Character unit)
    {
        unit.CleanDamageBeforeCombat();
        unit.CleanDamageAfterCombat();
    }
}