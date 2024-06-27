namespace Fire_Emblem
{
    public class AtkDefPush : Skill
    {
        private const int BonusValue = 7;
        private const double MinimumHpPercentage = 0.25;
        private const int PushBonus = 5;

        public AtkDefPush(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            if (IsHealthAboveThreshold(owner))
            {
                ApplyAttackDefenseBonus(owner);
                SetPushBonus(owner);
                ActivatePush(owner);
            }
        }

        private bool IsHealthAboveThreshold(Character owner)
        {
            return owner.CurrentHP >= MinimumHpPercentage * owner.MaxHP;
        }

        private void ApplyAttackDefenseBonus(Character owner)
        {
            owner.AddTemporaryBonus("Atk", BonusValue);
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