namespace Fire_Emblem {
    public class DistantDef : Skill {
        
        private Combat _combat;
        private Character _owner;
        private Character _opponent;
        private int _bonus = 8;
        public DistantDef(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);
            
            if (IsEffectApplicable()) {
                DoEffect();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            _combat = battle.CurrentCombat;
            _owner = owner;
            if (owner == _combat._attacker) {
                _opponent = _combat._defender;
            }else {
                _opponent = _combat._attacker;
            }
        }
        
        private bool IsEffectApplicable() {
            return _opponent == _combat._attacker && (_opponent.Weapon == "Magic" || _opponent.Weapon == "Bow");
        }
        
        private void DoEffect() {
            _owner.AddTemporaryBonus("Def", _bonus);
            _owner.AddTemporaryBonus("Res", _bonus);
            _opponent.DisableAllBonuses();
        }
    }
}