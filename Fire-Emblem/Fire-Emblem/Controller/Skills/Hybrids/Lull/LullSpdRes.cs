namespace Fire_Emblem {
    public class LullSpdRes : Skill {
        
        private Character _opponent;
        private int _spdPenalty = -3;
        private int _resPenalty = -3;
        public LullSpdRes(string name, string description) : base(name, description) {
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
            _opponent.AddTemporaryPenalty("Spd", _spdPenalty);
            _opponent.AddTemporaryPenalty("Res", _resPenalty);
        }
        
        private void DisableBonuses() {
            _opponent.AreSpdBonusesEnabled = false;
            _opponent.AreResBonusesEnabled = false;
        }
    }
}