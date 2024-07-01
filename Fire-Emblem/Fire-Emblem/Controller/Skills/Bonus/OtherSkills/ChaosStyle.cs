namespace Fire_Emblem {
    public class ChaosStyle : Skill {
        private int Bonus { get; set; }
        private Combat _combat;

        public ChaosStyle(string name, string description) : base(name, description) {
            Bonus = 3;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            _combat = battle.CurrentCombat;
            if (ShouldApplyEffect(owner)) {
                owner.AddTemporaryBonus("Spd", Bonus);
            }
        }
        private bool ShouldApplyEffect(Character owner) {
            bool isOwnerUsingPhysical = IsPhysicalWeapon(owner.Weapon);
            bool isOwnerUsingMagical = IsMagicalWeapon(owner.Weapon);
            bool isOpponentUsingMagical = IsMagicalWeapon(_combat._defender.Weapon);
            bool isOpponentUsingPhysical = IsPhysicalWeapon(_combat._defender.Weapon);
            bool isOwnerAttacker = _combat._attacker == owner;
            bool areWeaponsDifferentType = (isOwnerUsingPhysical && isOpponentUsingMagical) ||
                                           (isOwnerUsingMagical && isOpponentUsingPhysical);

            return isOwnerAttacker && areWeaponsDifferentType;
        }

        private bool IsPhysicalWeapon(string weapon) {
            return weapon == "Sword" || weapon == "Axe" || weapon == "Lance" || weapon == "Bow";
        }

        private bool IsMagicalWeapon(string weapon) {
            return weapon == "Magic";
        }
    }
}