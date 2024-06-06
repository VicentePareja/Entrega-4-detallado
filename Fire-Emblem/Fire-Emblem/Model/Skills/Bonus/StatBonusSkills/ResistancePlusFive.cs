namespace Fire_Emblem {
    public class ResistancePlusFive : Skill {
        private int Bonus { get; set; }

        public ResistancePlusFive(string name, string description) : base(name, description) {
            Bonus = 5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Res", Bonus);
   
        }
    }
}