namespace Fire_Emblem {
    public class LanceAgility : Skill {
        private int SpeedBonus { get; set; }
        private int AttackPenalty { get; set; }

        public LanceAgility(string name, string description) : base(name, description) {
            SpeedBonus = 12;
            AttackPenalty = -6;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.Weapon == "Lance") {
                owner.AddTemporaryBonus("Spd", SpeedBonus);
                owner.AddTemporaryPenalty("Atk", AttackPenalty);
            }
        }
    }
}