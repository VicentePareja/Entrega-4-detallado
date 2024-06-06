namespace Fire_Emblem {
    public class SwordPower : Skill {
        private int AttackBonus { get; set; }
        private int DefensePenalty { get; set; }

        public SwordPower(string name, string description) : base(name, description) {
            AttackBonus = 10;
            DefensePenalty = -10;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.Weapon == "Sword") {
                owner.AddTemporaryBonus("Atk", AttackBonus);
                owner.AddTemporaryPenalty("Def", DefensePenalty);
            }
        }
    }
}