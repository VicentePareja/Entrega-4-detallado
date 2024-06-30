namespace Fire_Emblem {
    public class Dragonskin : Skill {
        
        private double _hpThreshold = 0.75;
        private Combat _combat;
        private Character _owner;
        private Character _opponent;
        private int _bonus = 6;
        public Dragonskin(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            
            SetAttributes(battle, owner);
            if (IsEffectApllied()) {
                
                AddBonuses();
                _opponent.DisableAllBonuses();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            _combat = battle.CurrentCombat;
            _owner = owner;
            if (_owner == _combat._attacker) {
                _opponent = _combat._defender;
            }else {
                _opponent = _combat._attacker;
            }
        }
        public bool IsEffectApllied() {
            return _opponent == _combat._attacker || _opponent.CurrentHP >= _hpThreshold * _opponent.MaxHP;
        }
        
        public void AddBonuses() {
            _owner.AddTemporaryBonus("Atk", _bonus);
            _owner.AddTemporaryBonus("Spd", _bonus);
            _owner.AddTemporaryBonus("Def", _bonus);
            _owner.AddTemporaryBonus("Res", _bonus);
        }
    }
}