namespace Fire_Emblem {
    public class BowAgility : Skill {
        private int SpeedBonus { get; set; }
        private int AttackPenalty { get; set; }

        public BowAgility(string name, string description) : base(name, description) {
            SpeedBonus = 12;
            AttackPenalty = -6;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.Weapon == "Bow") {
                owner.AddTemporaryBonus("Spd", SpeedBonus);
                owner.AddTemporaryPenalty("Atk", AttackPenalty);
            }
        }
    }
}