namespace Fire_Emblem;

public class QuickRiposte : Skill
{
    public QuickRiposte(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        if(owner.CurrentHP >= owner.MaxHP *0.6 && battle.CurrentCombat._defender == owner )
        {
            owner.FollowUpGarantization += 1;
        }
    }

}