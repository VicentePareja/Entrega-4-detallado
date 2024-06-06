namespace Fire_Emblem {
    public class FairFightSkill : Skill {
        private int Bonus { get; set; }

        public FairFightSkill(string name, string description) : base(name, description) {
            Bonus = 6;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            if (combat._attacker == owner) {
                owner.AddTemporaryBonus("Atk", Bonus);
                combat._defender.AddTemporaryBonus("Atk", Bonus);
            }
        }
    }
}