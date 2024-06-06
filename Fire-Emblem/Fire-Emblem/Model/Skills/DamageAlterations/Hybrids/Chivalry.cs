namespace Fire_Emblem {
    public class Chivalry : DamageAlterationSkill {
        public Chivalry(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;
            bool isOpponentFullHP = opponent.CurrentHP == opponent.MaxHP;
            bool isOwnerAttacking = combat._attacker == owner;
            _counterTimes++;
            
            if (_counterTimes % 2 == 0)
            {
                if (IsEffectApplicable(isOpponentFullHP, isOwnerAttacking)) {
                    owner.AddTemporaryDamageAlteration("ExtraDamage", 2);
                    owner.AddTemporaryDamageAlteration("AbsoluteReduction", -2);
                }
            }
        }
        
        private bool IsEffectApplicable(bool isOppnentFullHP, bool isOwnerAtacking) {
            return isOppnentFullHP && isOwnerAtacking;
        }
    }
}