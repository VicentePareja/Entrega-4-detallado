namespace Fire_Emblem {
    public class SwordAgility : Skill {
        private int SpeedBonus { get; set; }
        private int AttackPenalty { get; set; }

        public SwordAgility(string name, string description) : base(name, description) {
            SpeedBonus = 12;
            AttackPenalty = -6; 
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.Weapon == "Sword") {
                owner.AddTemporaryBonus("Spd", SpeedBonus);
                owner.AddTemporaryPenalty("Atk", AttackPenalty);
            }
        }
    }
}