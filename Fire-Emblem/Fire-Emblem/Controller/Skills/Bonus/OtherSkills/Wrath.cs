namespace Fire_Emblem {
    public class Wrath : Skill {
        private int Bonus { get; set; }
        private int maxThreshold { get; set; }

        public Wrath(string name, string description) : base(name, description) {
            Bonus = 1;
            maxThreshold = 30;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            int hpLost = owner.MaxHP - owner.CurrentHP;

            int totalBonus = Math.Min(hpLost, maxThreshold);

            owner.AddTemporaryBonus("Atk", totalBonus);
            owner.AddTemporaryBonus("Spd", totalBonus);
        }
    }
}