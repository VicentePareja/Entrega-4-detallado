namespace Fire_Emblem {
    public class LifeAndDeath : Skill {
        
        private int _atkBonus = 6;
        private int _spdBonus = 6;
        private int _defPenalty = -5;
        private int _resPenalty = -5;
        public LifeAndDeath(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Atk", _atkBonus);
            owner.AddTemporaryBonus("Spd", _spdBonus);
            owner.AddTemporaryPenalty("Def", _defPenalty);
            owner.AddTemporaryPenalty("Res", _resPenalty);
        }
    }
}