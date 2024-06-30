namespace Fire_Emblem {
    public class WillToWin : Skill {
        private int Bonus { get; set; }
        private double Threshold { get; set; }

        public WillToWin(string name, string description) : base(name, description) {
            Bonus = 8;
            Threshold = 0.5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {

            if (owner.CurrentHP <= owner.MaxHP * Threshold) {
                owner.AddTemporaryBonus("Atk", Bonus);
            }
        }
    }
}