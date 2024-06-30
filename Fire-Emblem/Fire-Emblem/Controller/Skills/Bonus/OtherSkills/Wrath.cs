namespace Fire_Emblem {
    public class Wrath : Skill {
        private int Bonus { get; set; }
        private int Threshold { get; set; }

        public Wrath(string name, string description) : base(name, description) {
            Bonus = 1;
            Threshold = 30;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            int hpLost = owner.MaxHP - owner.CurrentHP;

            int totalBonus = Math.Min(hpLost, Threshold);

            owner.AddTemporaryBonus("Atk", totalBonus);
            owner.AddTemporaryBonus("Spd", totalBonus);
        }
    }
}