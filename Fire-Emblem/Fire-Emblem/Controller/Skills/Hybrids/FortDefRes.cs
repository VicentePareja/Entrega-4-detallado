namespace Fire_Emblem {
    public class FortDefRes : Skill {
        
        private int _defBonus = 6;
        private int _resBonus = 6;
        private int _atkPenalty = -2;
        public FortDefRes(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            owner.AddTemporaryBonus("Def", _defBonus);
            owner.AddTemporaryBonus("Res", _resBonus);
            owner.AddTemporaryPenalty("Atk", _atkPenalty);
        }
    }
}