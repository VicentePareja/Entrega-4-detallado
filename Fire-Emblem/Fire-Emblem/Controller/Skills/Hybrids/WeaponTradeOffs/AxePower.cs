namespace Fire_Emblem {
    public class AxePower : Skill {
        private int AttackBonus { get; set; }
        private int DefensePenalty { get; set; }

        public AxePower(string name, string description) : base(name, description) {
            AttackBonus = 10;
            DefensePenalty = -10;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.Weapon == "Axe") {
                owner.AddTemporaryBonus("Atk", AttackBonus);
                owner.AddTemporaryPenalty("Def", DefensePenalty);
            }
        }
    }
}