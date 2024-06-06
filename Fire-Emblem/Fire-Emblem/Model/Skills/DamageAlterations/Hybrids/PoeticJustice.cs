namespace Fire_Emblem;

public class PoeticJustice : DamageAlterationSkill
{
    public PoeticJustice(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        Combat combat = battle.CurrentCombat;
        Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;
        double extraDamage = (double)opponent.GetEffectiveAttribute("Atk") * 0.15;
        _counterTimes++;
        
        if (_counterTimes % 2 == 0)
        {
            owner.AddTemporaryDamageAlteration("ExtraDamage", extraDamage);
        }
        if (_counterTimes % 2 == 1)
        {
            opponent.AddTemporaryPenalty("Spd", -4);
        }
        

        
        
    }
}