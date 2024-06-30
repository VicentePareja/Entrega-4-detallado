namespace Fire_Emblem {
    public class ExtraChivalry : DamageAlterationSkill {
        int _penalty;
        private double _healthPercentage;
        private Character _owner;
        private Combat _combat;
        private Character _opponent;
        public ExtraChivalry(string name, string description) : base(name, description){ 
            _penalty = -5;
            _healthPercentage = 0.5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            
            SetAttributes(battle, owner);

            if (IsPenaltyApplicable())
            {
                AddPenalties();
            }
            if (IsDamageAlteration())
            {
                ApplyDamageAlterations();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            _counterTimes++;
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
        }
        
        private bool IsPenaltyApplicable() {
            return _counterTimes % 2 == 1 && _opponent.CurrentHP >= _opponent.MaxHP * _healthPercentage;
        }
        private void AddPenalties() {
            _opponent.AddTemporaryPenalty("Atk", _penalty);
            _opponent.AddTemporaryPenalty("Spd", _penalty);
            _opponent.AddTemporaryPenalty("Def", _penalty);
        }
        
        private bool IsDamageAlteration() {
            return _counterTimes % 2 == 0;
        }
        
        private void ApplyDamageAlterations() {
            int hpPercentage = (int)((double)_opponent.CurrentHP / _opponent.MaxHP * 100);
            int damageReductionPercentage = hpPercentage / 2;
            _owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
        }
    }
}