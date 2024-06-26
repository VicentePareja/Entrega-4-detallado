namespace Fire_Emblem {
    public class AtkDefPlusFive : Skill {
        private int Bonus { get; set; }

        public AtkDefPlusFive(string name, string description) : base(name, description) {
            Bonus = 5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Atk", Bonus);
            owner.AddTemporaryBonus("Def", Bonus);
   
        }
    }
}