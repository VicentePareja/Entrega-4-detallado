namespace Fire_Emblem {
    public class Resolve : Skill {
        private int Bonus { get; set; }
        private double Threshold { get; set; }

        public Resolve(string name, string description) : base(name, description) {
            Bonus = 7;
            Threshold = 0.75;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
        
            if (owner.CurrentHP <= owner.MaxHP * Threshold) {
                owner.AddTemporaryBonus("Def", Bonus);
                owner.AddTemporaryBonus("Res", Bonus);
            }
        }
    }
}