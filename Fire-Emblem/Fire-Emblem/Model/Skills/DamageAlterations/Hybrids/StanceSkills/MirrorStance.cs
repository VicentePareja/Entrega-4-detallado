namespace Fire_Emblem;

public class MirrorStance : DamageAlterationSkill
{
    private int bonus;
    private int reduction;
    public MirrorStance(string name, string description) : base(name, description)
    {
        bonus = 6;
        reduction = 10;
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;

        if (combat._attacker != owner)
        {

            owner.AddTemporaryBonus("Atk", bonus);
            owner.AddTemporaryBonus("Res", bonus);

            owner.MultiplyFollowUpDamageAlterations("PercentageReduction", reduction);
        }
    }
}