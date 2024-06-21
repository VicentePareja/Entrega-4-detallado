namespace Fire_Emblem {
    public class SpdResPlusFive : Skill {
        private int Bonus { get; set; }

        public SpdResPlusFive(string name, string description) : base(name, description) {
            Bonus = 5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Spd", Bonus);
            owner.AddTemporaryBonus("Res", Bonus);
   
        }
    }
}