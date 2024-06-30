namespace Fire_Emblem {
    public class StillWater : Skill {
        
        private int _atkBonus = 6;
        private int _resBonus = 6;
        private int _defPenalty = -5;
        public StillWater(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Atk", _atkBonus);
            owner.AddTemporaryBonus("Res", _resBonus);
            owner.AddTemporaryPenalty("Def", _defPenalty);
        }
    }
}