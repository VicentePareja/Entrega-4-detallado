namespace Fire_Emblem {
    public class LullAtkSpd : Skill {
        
        private Character _opponent;
        private int _atkPenalty = -3;
        private int _spdPenalty = -3;
        public LullAtkSpd(string name, string description) : base(name, description) {
            
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
            _opponent.AddTemporaryPenalty("Atk", _atkPenalty);
            _opponent.AddTemporaryPenalty("Spd", _spdPenalty);
        }
        
        private void DisableBonuses() {
            _opponent.AreAtkBonusesEnabled = false;
            _opponent.AreSpdBonusesEnabled = false;
        }
    }
}