namespace Fire_Emblem {
    public class BrazenSpdDef : Skill {
        private int Bonus { get; set; }
        private double Threshold { get; set; }

        public BrazenSpdDef(string name, string description) : base(name, description) {
            Bonus = 10;
            Threshold = 0.8;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.CurrentHP <= owner.MaxHP * Threshold) {
                owner.AddTemporaryBonus("Spd", Bonus);
                owner.AddTemporaryBonus("Def", Bonus);
            }
        }
    }
}