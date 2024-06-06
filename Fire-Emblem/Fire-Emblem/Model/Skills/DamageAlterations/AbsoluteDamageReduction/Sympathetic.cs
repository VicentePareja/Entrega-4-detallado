namespace Fire_Emblem;

public class Sympathetic : DamageAlterationSkill
{
    public Sympathetic(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        _counterTimes++;
        if (_counterTimes % 2 == 0)
        {
            Combat combat = battle.CurrentCombat;
            bool isInitiatorOpponent = combat._attacker != owner;
            bool isOwnerHealthLow = owner.CurrentHP <= owner.MaxHP * 0.5;
            if (isInitiatorOpponent && isOwnerHealthLow)
            {
                double damageReduction = -5.0;
                owner.AddTemporaryDamageAlteration("AbsoluteReduction", damageReduction);
            }
            
        } 
    }
}