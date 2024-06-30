namespace Fire_Emblem;

public class FollowUpRing : Skill
{
    private double _hpThreshold = 0.5;
    public FollowUpRing(string name, string description) : base(name, description)
    {
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        if(owner.CurrentHP >= owner.MaxHP * _hpThreshold)
        {
            owner.FollowUpGarantization += 1;
        }
    }
}