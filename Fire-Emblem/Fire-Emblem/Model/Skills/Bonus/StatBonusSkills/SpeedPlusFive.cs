namespace Fire_Emblem {
    public class SpeedPlusFive : Skill {
        private int Bonus { get; set; }

        public SpeedPlusFive(string name, string description) : base(name, description) {
            Bonus = 5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Spd", Bonus);
   
        }
    }
}