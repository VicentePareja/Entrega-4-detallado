namespace Fire_Emblem
{
    public class SpdDefPush : Skill
    {
        private const int BonusValue = 7;
        private const double MinimumHpPercentage = 0.25;
        private const int PushBonus = 5;

        public SpdDefPush(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            if (IsHealthAboveThreshold(owner))
            {
                ApplySpeedDefenseBonus(owner);
                SetPushBonus(owner);
                ActivatePush(owner);
            }
        }

        private bool IsHealthAboveThreshold(Character owner)
        {
            return owner.CurrentHP >= MinimumHpPercentage * owner.MaxHP;
        }

        private void ApplySpeedDefenseBonus(Character owner)
        {
            owner.AddTemporaryBonus("Spd", BonusValue);
            owner.AddTemporaryBonus("Def", BonusValue);
        }

        private void SetPushBonus(Character owner)
        {
            owner.pushBonus = PushBonus;
        }

        private void ActivatePush(Character owner)
        {
            owner.SetPushActive();
        }
    }
}