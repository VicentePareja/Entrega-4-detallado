namespace Fire_Emblem;
public class ArmsShield : DamageAlterationSkill
{
    public ArmsShield(string name, string description) : base(name, description)
    {
        
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        _counterTimes++;
        ApplyDamageEffect(battle, owner);
    }

    private void ApplyDamageEffect(Battle battle, Character owner)
    {
        if (_counterTimes % 2 == 0)
        {
            Combat combat = battle.CurrentCombat;
            if (HasOwnerAdvantage(combat, owner))
            {
                double damageReduction = -7.0;
                owner.AddTemporaryDamageAlteration("AbsoluteReduction", damageReduction);
            }
        }
    }
    
    private bool HasOwnerAdvantage(Combat combat, Character owner)
    {
        string advantage = combat._advantage;
        return (advantage == "atacante" && combat._attacker == owner) ||
               (advantage == "defensor" && combat._defender == owner);
    }
}