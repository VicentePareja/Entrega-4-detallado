namespace Fire_Emblem {
    public class DeadlyBladeSkill : Skill {
        private int Bonus { get; set; }

        public DeadlyBladeSkill(string name, string description) : base(name, description) {
            Bonus = 8;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            if (combat._attacker == owner) {
                if (owner.Weapon == "Sword")
                {
                    owner.AddTemporaryBonus("Atk", Bonus);
                    owner.AddTemporaryBonus("Spd", Bonus);
                }
            }
        }
    }
}