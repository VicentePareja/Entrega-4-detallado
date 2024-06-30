namespace Fire_Emblem {
    public class DragonsWrath : DamageAlterationSkill
    {

        private Combat _combat;
        private Character _opponent;
        private Character _owner;
        private readonly int _percentageReduction = 25;
        private readonly double _extraDamagePonderator = 0.25;

        public DragonsWrath(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);

            if (IsDamageAlterationApplicable())
            {
               ApplyDamageAlterations();
            }
        }

        private void SetAttributes(Battle battle, Character owner)
        {
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
            _counterTimes++;
        }

        private bool IsDamageAlterationApplicable()
        {
            return _counterTimes % 2 == 0;
        }
        
        private void ApplyDamageAlterations()
        {
            _owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", _percentageReduction);
            if (_owner.GetEffectiveAttribute("Atk") > _opponent.GetEffectiveAttribute("Res"))
            {
                double extraDamage = _extraDamagePonderator * (_owner.Atk - _opponent.Res);
                _owner.AddFirstAttackDamageAlteration("ExtraDamage", extraDamage);
            }
        }
    }
}