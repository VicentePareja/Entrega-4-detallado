namespace Fire_Emblem {
    public class WaterBoost : Skill {
        private int Bonus { get; set; }
        private int hpDifference;
        private Character thisCharacter;
        private Character otherCharacter;

        public WaterBoost(string name, string description) : base(name, description) {
            Bonus = 6;
            hpDifference = 3;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            
            SetAttributes(battle, owner);

            if (IsEffect()) {
                owner.AddTemporaryBonus("Res", Bonus);
            }
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            
            if (owner == combat._attacker) {
                thisCharacter = combat._attacker;
                otherCharacter = combat._defender;
            } else {
                thisCharacter = combat._defender;
                otherCharacter = combat._attacker;
            }
        }
        
        private bool IsEffect() {
            return thisCharacter.CurrentHP >= otherCharacter.CurrentHP + hpDifference;
        }
    }
}