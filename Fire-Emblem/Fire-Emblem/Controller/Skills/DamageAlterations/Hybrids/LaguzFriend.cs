namespace Fire_Emblem {
    public class LaguzFriend : DamageAlterationSkill {
        public LaguzFriend(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            
            _counterTimes++;
            if (_counterTimes % 2 == 0)
            {
                owner.MultiplyTemporaryDamageAlterations("PercentageReduction", 50);
                owner.AreDefBonusesEnabled = false;
                owner.AreResBonusesEnabled = false;
            }
            if (_counterTimes % 2 == 1)
            {
                int defPenalty = -(int)(owner.GetBaseAttributeValue("Def") * 0.5);
                int resPenalty = -(int)(owner.GetBaseAttributeValue("Res") * 0.5);
                owner.AddTemporaryPenalty("Def", defPenalty);
                owner.AddTemporaryPenalty("Res", resPenalty);
            }
        }
    }
}