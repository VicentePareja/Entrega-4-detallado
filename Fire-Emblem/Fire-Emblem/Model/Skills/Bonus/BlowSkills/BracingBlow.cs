namespace Fire_Emblem {
    public class BracingBlow : BlowSkill {
        private int DefBonus { get; set; }
        private int ResBonus { get; set; }

        public BracingBlow(string name, string description) : base(name, description) {
            DefBonus = 6;
            ResBonus = 6;
        }

        protected override void ApplySpecificEffect(Character owner) {
            owner.AddTemporaryBonus("Def", DefBonus);
            owner.AddTemporaryBonus("Res", ResBonus);
        }
    }
}