namespace Fire_Emblem {
    public class CloseDef : Skill {
        
        private Combat _combat;
        private Character _opponent;
        private Character _owner;
        public CloseDef(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            
            SetAttributes(battle, owner);
            
            if (IsDefenderAndAttackerClose()) {
                
                DoEffect();
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
        
        private bool IsDefenderAndAttackerClose() {
            string weapon = _opponent.Weapon;
            return _opponent == _combat._attacker && (weapon == "Sword" || weapon == "Lance" || weapon == "Axe");
        }
        
        private void DoEffect() {
            _owner.AddTemporaryBonus("Def", 8);
            _owner.AddTemporaryBonus("Res", 8);
            _opponent.DisableAllBonuses();
        }
    }
}