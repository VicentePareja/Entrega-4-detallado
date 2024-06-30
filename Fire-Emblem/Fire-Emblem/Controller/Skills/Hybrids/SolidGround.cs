namespace Fire_Emblem {
    public class SolidGround : Skill {
        
        private int _atkBonus = 6;
        private int _defBonus = 6;
        private int _resPenalty = -5;
        public SolidGround(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Atk", _atkBonus);
            owner.AddTemporaryBonus("Def", _defBonus);
            
            owner.AddTemporaryPenalty("Res", _resPenalty);
        }
    }
}