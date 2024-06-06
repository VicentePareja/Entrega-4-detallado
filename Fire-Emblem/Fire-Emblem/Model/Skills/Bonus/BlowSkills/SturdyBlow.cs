namespace Fire_Emblem {
    public class SturdyBlow : BlowSkill {
        private int AtkBonus { get; set; }
        private int DefBonus { get; set; }

        public SturdyBlow(string name, string description) : base(name, description) {
            AtkBonus = 6;
            DefBonus = 6;
        }

        protected override void ApplySpecificEffect(Character owner) {
            owner.AddTemporaryBonus("Atk", AtkBonus);
            owner.AddTemporaryBonus("Def", DefBonus);
        }
    }
}