namespace Fire_Emblem {
    public class DefensePlusFive : Skill {
        private int Bonus { get; set; }

        public DefensePlusFive(string name, string description) : base(name, description) {
            Bonus = 5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Def", Bonus);
   
        }
    }
}