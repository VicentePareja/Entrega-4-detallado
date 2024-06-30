namespace Fire_Emblem {
    public class LullSpdDef : Skill {
        
        private Character _opponent;
        private int _defPenalty = -3;
        private int _spdPenalty = -3;
        public LullSpdDef(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);
            ApplyPenalty();
            DisableBonuses();
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            if (battle.CurrentCombat._attacker == owner) {
                _opponent = battle.CurrentCombat._defender;
            } else {
                _opponent = battle.CurrentCombat._attacker;
            }
        }
        
        private void ApplyPenalty() {
            _opponent.AddTemporaryPenalty("Def", _defPenalty);
            _opponent.AddTemporaryPenalty("Spd", _spdPenalty);
        }
        
        private void DisableBonuses() {
            _opponent.AreDefBonusesEnabled = false;
            _opponent.AreSpdBonusesEnabled = false;
        }
    }
}