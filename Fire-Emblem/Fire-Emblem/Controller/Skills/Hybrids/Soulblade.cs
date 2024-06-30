namespace Fire_Emblem {
    public class Soulblade : Skill {
        
        private Combat _combat;
        private Character _owner;
        private Character _opponent;
        public Soulblade(string name, string description) : base(name, description) {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);

            if (IsWeaponSword()) {
  
                DoEffect();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner) {
            _combat = battle.CurrentCombat;
            _owner = owner;
            _opponent = (_combat._attacker == owner) ? _combat._defender : _combat._attacker;
        }
        
        private bool IsWeaponSword() {
            return _owner.Weapon == "Sword";
        }
        
        private void DoEffect() {
            double averageDefRes = (_opponent.Def + _opponent.Res) / 2.0;
            int changeDef = Convert.ToInt32(Math.Floor(averageDefRes - _opponent.Def));
            int changeRes = Convert.ToInt32(Math.Floor(averageDefRes - _opponent.Res));

            if (changeDef < 0 || changeRes < 0) {
                Console.WriteLine("Applying penalties.");
            }

            ApplyAttributeChange( "Def", changeDef);
            ApplyAttributeChange( "Res", changeRes);
        }

        private void ApplyAttributeChange(string attribute, int change) {
            if (change > 0) {
                _opponent.AddTemporaryBonus(attribute, change);
            } else if (change < 0) {
                _opponent.AddTemporaryPenalty(attribute, change);
            }
        }
    }
}