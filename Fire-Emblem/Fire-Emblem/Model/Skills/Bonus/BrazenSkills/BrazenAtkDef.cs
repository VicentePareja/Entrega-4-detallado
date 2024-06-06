namespace Fire_Emblem {
    public class BrazenAtkDef : Skill {
        private int Bonus { get; set; }

        public BrazenAtkDef(string name, string description) : base(name, description) {
            Bonus = 10;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.CurrentHP <= owner.MaxHP * 0.8) {
                owner.AddTemporaryBonus("Atk", Bonus);
                owner.AddTemporaryBonus("Def", Bonus);
            }
        }
    }
}