namespace Fire_Emblem;

public class KestrelStance : DamageAlterationSkill
{
    private int bonus = 6;
    private int reduction = 10;
    public KestrelStance(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;
        _counterTimes++;

        if (combat._attacker != owner && _counterTimes % 2 == 1)
        {

            owner.AddTemporaryBonus("Atk", bonus);
            owner.AddTemporaryBonus("Spd", bonus);
        }
        
        if (combat._attacker != owner && _counterTimes % 2 == 0)
        { 
            owner.MultiplyFollowUpDamageAlterations("PercentageReduction", reduction);
        }
    }
}