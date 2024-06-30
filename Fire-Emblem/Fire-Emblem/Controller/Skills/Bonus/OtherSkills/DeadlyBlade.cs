namespace Fire_Emblem {
    public class DeadlyBladeSkill : Skill
    {
        private int Bonus { get; set; }
        private string _weapon;
        private Character _owner;
        private Combat _combat;

        public DeadlyBladeSkill(string name, string description) : base(name, description)
        {
            Bonus = 8;
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);

            if (IsEffectApplicable())
            {
                ApplyBonus();
            }
        }

        private void SetAttributes(Battle battle, Character owner)
        {
            _combat = battle.CurrentCombat;
            _weapon = "Sword";
            _owner = owner;
        }

        private bool IsEffectApplicable()
        {
            return _combat._attacker == _owner && _owner.Weapon == _weapon;
        }

        private void ApplyBonus()
        {
            _owner.AddTemporaryBonus("Atk", Bonus);
            _owner.AddTemporaryBonus("Spd", Bonus);
        }
    }
}