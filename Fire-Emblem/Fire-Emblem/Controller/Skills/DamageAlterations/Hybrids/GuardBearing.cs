namespace Fire_Emblem {
    public class GuardBearing : DamageAlterationSkill {
        
        private bool _firstCombatInitiatedByUnit = false;
        private bool _firstCombatInitiatedByOpponent = false;
        private Character _owner;
        private Combat _combat;
        private Character _opponent;
        private int _penalty = -4;
        public GuardBearing(string name, string description) : base(name, description) {
        }
        public override void ApplyEffect(Battle battle, Character owner) {
            
            SetAttributes(battle, owner);
            if (IsStatPenaltyApplicable()) {
                ApplyStatPenalties();
            }
            if (IsDamageAlteration())
            {
                AppyDamageAlteration();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            _counterTimes++;
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
        }
        
        private bool IsStatPenaltyApplicable() {
            return _counterTimes % 2 == 1;
        }

        private void ApplyStatPenalties() {
            _opponent.AddTemporaryPenalty("Spd", _penalty);
            _opponent.AddTemporaryPenalty("Def", _penalty);
        }

        private bool IsDamageAlteration() {
            return _counterTimes % 2 == 0;
        }
        
        private void AppyDamageAlteration() {
            int damageReduction = CalculateDamageReduction();
            ApplyDamageReduction(damageReduction);
        }
        private int CalculateDamageReduction() {
            if ((_combat._attacker == _owner && !_firstCombatInitiatedByUnit) ||
                (_combat._attacker != _owner && !_firstCombatInitiatedByOpponent)) {
                UpdateCombatFlags(_combat, _owner);
                return 60;
            } else {
                return 30;
            }
        }
        
        private void ApplyDamageReduction(int damageReductionPercentage) {
            _owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
        }
        private void UpdateCombatFlags(Combat combat, Character owner) {
            if (combat._attacker == owner) {
                _firstCombatInitiatedByUnit = true;
            } else {
                _firstCombatInitiatedByOpponent = true;
            }
        }
    }
}