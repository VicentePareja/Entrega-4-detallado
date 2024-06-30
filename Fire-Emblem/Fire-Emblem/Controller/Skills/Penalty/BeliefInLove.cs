namespace Fire_Emblem {
    public class BeliefInLove : Skill {
        private int Penalty { get; set; }

        public BeliefInLove(string name, string description) : base(name, description) {
            Penalty = -5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;

            if (IsEffectApplied(battle, owner)) {
                ApplyPenalty(opponent);
            }
        }
        private bool IsEffectApplied(Battle battle, Character owner) {
            
            Combat combat = battle.CurrentCombat;
            Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;
            return combat._attacker != owner || opponent.CurrentHP == opponent.MaxHP;
        }
        
        private void ApplyPenalty(Character opponent) {
            opponent.AddTemporaryPenalty("Atk", Penalty);
            opponent.AddTemporaryPenalty("Def", Penalty);
        }
    }
}