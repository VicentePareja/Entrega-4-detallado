namespace Fire_Emblem;

public class FollowUpRing : Skill
{
    public FollowUpRing(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        if(owner.CurrentHP >= owner.MaxHP *0.5)
        {
            owner.FollowUpGarantization += 1;
        }
    }
}