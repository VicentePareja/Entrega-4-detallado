namespace Fire_Emblem {
    public class DartingBlow : BlowSkill {
        private int Bonus { get; set; }

        public DartingBlow(string name, string description) : base(name, description) {
            Bonus = 8; 
        }

        protected override void ApplySpecificEffect(Character owner) {
            owner.AddTemporaryBonus("Spd", Bonus);
        }
    }
}