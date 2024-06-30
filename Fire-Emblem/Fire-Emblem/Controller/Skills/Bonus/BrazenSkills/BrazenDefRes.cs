namespace Fire_Emblem
{
    public class BrazenDefRes : Skill {
        private int Bonus { get; set; }
        private double Threshold { get; set; }

        public BrazenDefRes(string name, string description) : base(name, description) {
            Bonus = 10;
            Threshold = 0.8;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.CurrentHP <= owner.MaxHP * Threshold) {
                owner.AddTemporaryBonus("Def", Bonus);
                owner.AddTemporaryBonus("Res", Bonus);
            }
        }
    }
}