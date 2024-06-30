using System;

namespace Fire_Emblem
{
    public class Dodge : DamageAlterationSkill
    {
        private Combat _combat;
        private Character _opponent;
        private Character _owner;
        private int _speedDifference;
        private int _maxPercentageReduction = 40;
        private int _speedPonderator = 4;
        public Dodge(string name, string description) : base(name, description) {}

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);
            if (IsDamageReduction())
            {
                ApplyDamageEffect();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner)
        {
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = (_combat._attacker == owner) ? _combat._defender : _combat._attacker;
            _speedDifference = _owner.GetEffectiveAttribute("Spd") - _opponent.GetEffectiveAttribute("Spd");
            _counterTimes++;
        }
        
        private bool IsDamageReduction()
        {
            return _counterTimes % 2 == 0;
        }

        private void ApplyDamageEffect()
        {
            if (_speedDifference > 0)
            {
                int damageReductionPercentage = Math.Min(_speedDifference * _speedPonderator, _maxPercentageReduction);
                _owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
            }
        }
    }
}