namespace Fire_Emblem {
    public class WindBoost : Skill {
        private int Bonus { get; set; }
        private Character _owner;
        private Combat _combat;
        private Character _opponent;
        public WindBoost(string name, string description) : base(name, description) {
            Bonus = 6;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            
            SetAttributes(battle, owner);

            if (_owner.CurrentHP >= _opponent.CurrentHP + 3) {
                owner.AddTemporaryBonus("Spd", Bonus);
            }
        }
        
        private void SetAttributes(Battle battle, Character owner)
        {
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = _owner == _combat._attacker ? _combat._defender : _combat._attacker;

        }
    }
}