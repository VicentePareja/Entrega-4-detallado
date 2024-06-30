namespace Fire_Emblem {
    public class LightAndDark : Skill {
        
        private int _penalty = -5;
        private Combat _combat;
        private Character _owner;
        private Character _opponent;
        public LightAndDark(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            
            SetAttributes(battle, owner);
            AddPenalties();
            _owner.DisableAllPenalties();
            _opponent.DisableAllBonuses();
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            _combat = battle.CurrentCombat;
            _owner = owner;
            _opponent = (_combat._attacker == owner) ? _combat._defender : _combat._attacker;
        }
        
        private void AddPenalties() {
            _opponent.AddTemporaryPenalty("Atk", _penalty);
            _opponent.AddTemporaryPenalty("Spd", _penalty);
            _opponent.AddTemporaryPenalty("Def", _penalty);
            _opponent.AddTemporaryPenalty("Res", _penalty);
        }
    }
}