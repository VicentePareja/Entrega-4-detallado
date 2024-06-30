namespace Fire_Emblem {
    public class Prescience : DamageAlterationSkill
    {

        private int _percentageReduction = 30;
        private int _penalty = -5;
        private Character _owner;
        private Combat _combat;
        private Character _opponent;
        private bool _opponentUsesMagicOrBow;

        public Prescience(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {

            SetAttributes(battle, owner);

            if (IsDamageAlteration())
            {
                ApplyDamageAlterations();
            }

            if (IsPenaltyApplicable())
            {
                ApplyPenalties();
            }
        }

        private void SetAttributes(Battle battle, Character owner)
        {
            _counterTimes++;
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
            _opponentUsesMagicOrBow = _opponent.Weapon == "Magic" || _opponent.Weapon == "Bow";
        }

        private bool IsDamageAlteration()
        {
            return _counterTimes % 2 == 0 && (_combat._attacker == _owner || _opponentUsesMagicOrBow);
        }

        private void ApplyDamageAlterations()
        {
            _owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", _percentageReduction);
        }
        private bool IsPenaltyApplicable()
        {
            return _counterTimes % 2 == 1;
        }
        private void ApplyPenalties()
        {
            _opponent.AddTemporaryPenalty("Atk", _penalty);
            _opponent.AddTemporaryPenalty("Res", _penalty);
        }
    }
}