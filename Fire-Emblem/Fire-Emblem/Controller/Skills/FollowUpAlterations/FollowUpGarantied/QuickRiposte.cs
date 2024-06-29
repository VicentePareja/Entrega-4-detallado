namespace Fire_Emblem;

public class QuickRiposte : Skill
{
    private const double HealthThresholdMultiplier = 0.6;

    public QuickRiposte(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        if (ShouldActivateEffect(owner, battle))
        {
            owner.FollowUpGarantization += 1;
        }
    }

    private bool ShouldActivateEffect(Character owner, Battle battle)
    {
        bool isHealthAboveThreshold = owner.CurrentHP >= owner.MaxHP * HealthThresholdMultiplier;
        bool isDefender = battle.CurrentCombat._defender == owner;

        return isHealthAboveThreshold && isDefender;
    }
}