namespace Fire_Emblem {
    public class WaterBoost : Skill {
        private int Bonus { get; set; }
        private int _HPDifference { get; set; }

        public WaterBoost(string name, string description) : base(name, description) {
            Bonus = 6;
            _HPDifference = 3;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            Character otherCharacter;
            Character thisCharacter;

            if (owner == combat._attacker) {
                thisCharacter = combat._attacker;
                otherCharacter = combat._defender;
            } else {
                thisCharacter = combat._defender;
                otherCharacter = combat._attacker;
            }

            if (thisCharacter.CurrentHP >= otherCharacter.CurrentHP + _HPDifference) {
                owner.AddTemporaryBonus("Res", Bonus);
            }
        }
    }
}