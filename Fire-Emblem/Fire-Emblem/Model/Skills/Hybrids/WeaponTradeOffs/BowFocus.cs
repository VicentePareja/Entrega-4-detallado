namespace Fire_Emblem {
    public class BowFocus : Skill {
        private int AttackBonus { get; set; }
        private int ResistancePenalty { get; set; }

        public BowFocus(string name, string description) : base(name, description) {
            AttackBonus = 10;
            ResistancePenalty = -10;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.Weapon == "Bow") {
                owner.AddTemporaryBonus("Atk", AttackBonus);
                owner.AddTemporaryPenalty("Res", ResistancePenalty);
            }
        }
    }
}