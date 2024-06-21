namespace Fire_Emblem {
    public class DeathBlow : BlowSkill {
        private int Bonus { get; set; }

        public DeathBlow(string name, string description) : base(name, description) {
            Bonus = 8;
        }

        protected override void ApplySpecificEffect(Character owner) {
            owner.AddTemporaryBonus("Atk", Bonus);
        }
    }
}