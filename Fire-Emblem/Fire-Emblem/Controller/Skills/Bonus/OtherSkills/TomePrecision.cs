namespace Fire_Emblem {
    public class TomePrecision : Skill {
        private int Bonus { get; set; }

        public TomePrecision(string name, string description) : base(name, description) {
            Bonus = 6;
        }

        public override void ApplyEffect(Battle battle, Character owner) {

            if (owner.Weapon == "Magic") {
                owner.AddTemporaryBonus("Spd", Bonus);
                owner.AddTemporaryBonus("Atk", Bonus);
            }
        }
    }
}