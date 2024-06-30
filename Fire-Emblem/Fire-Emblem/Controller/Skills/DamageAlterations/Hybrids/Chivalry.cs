namespace Fire_Emblem {
    public class Chivalry : DamageAlterationSkill {
        
        private int _extraDamage = 2;
        private int _absoluteReduction = -2;
        private Combat _combat;
        private Character _owner;
        private Character _opponent;
        private bool _isOwnerAttacking;
        private bool _isOpponentFullHP;
        public Chivalry(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);
            
            if (IsEffectApplicable()) {
                ApplyDamageAlterations();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            _counterTimes++;
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
            _isOwnerAttacking = _combat._attacker == _owner;
            _isOpponentFullHP = _opponent.CurrentHP == _opponent.MaxHP;
        }
        
        private bool IsEffectApplicable() {
            return _isOpponentFullHP && _isOwnerAttacking && _counterTimes % 2 == 0;
        }
        
        private void ApplyDamageAlterations() {
            _owner.AddTemporaryDamageAlteration("ExtraDamage", _extraDamage);
            _owner.AddTemporaryDamageAlteration("AbsoluteReduction", _absoluteReduction);
        }
    }
}