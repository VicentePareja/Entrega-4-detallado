namespace Fire_Emblem {
    public class Luna : Skill {
        
        private double _activationRate = 0.5;
        public Luna(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;
            ApplyPenalties(opponent);
        }
        
        private void ApplyPenalties(Character opponent) {
            int penaltyDef = -(int)Math.Floor(opponent.Def * _activationRate);
            int penaltyRes = -(int)Math.Floor(opponent.Res * _activationRate);
            opponent.AddTemporaryFirstAttackPenalties("Def", penaltyDef);
            opponent.AddTemporaryFirstAttackPenalties("Res", penaltyRes);
        }
    }
}