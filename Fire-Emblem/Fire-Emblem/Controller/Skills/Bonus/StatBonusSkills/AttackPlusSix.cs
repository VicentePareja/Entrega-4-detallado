namespace Fire_Emblem {
    public class AttackPlusSix : Skill {
        private int Bonus { get; set; }

        public AttackPlusSix(string name, string description) : base(name, description) {
            Bonus = 6;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Atk", Bonus);
   
        }
    }
}