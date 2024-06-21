namespace Fire_Emblem {
    public class Prescience : DamageAlterationSkill {
        public Prescience(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;
            bool opponentUsesMagicOrBow = opponent.Weapon == "Magic" || opponent.Weapon == "Bow";
            _counterTimes++;
            
            if (_counterTimes % 2 == 0) {
                if (combat._attacker == owner || opponentUsesMagicOrBow) {
                    owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", 30);
                }
            }
            if (_counterTimes % 2 == 1) {
                opponent.AddTemporaryPenalty("Atk", -5);
                opponent.AddTemporaryPenalty("Res", -5);
            }
        }
    }
}