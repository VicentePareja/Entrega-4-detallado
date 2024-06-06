using System;

namespace Fire_Emblem
{
    public class Dodge : DamageAlterationSkill
    {
        private Combat _combat;
        private Character _opponent;
        private Character _owner;
        private int _speedDifference;
        public Dodge(string name, string description) : base(name, description) {}

        public override void ApplyEffect(Battle battle, Character owner)
        {
            _counterTimes++;
            if (_counterTimes % 2 == 0)
            {
                SetAttributes(battle, owner);
                ApplyDamageEffect();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner)
        {
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = (_combat._attacker == owner) ? _combat._defender : _combat._attacker;
            _speedDifference = _owner.GetEffectiveAttribute("Spd") - _opponent.GetEffectiveAttribute("Spd");
        }

        private void ApplyDamageEffect()
        {
            if (_speedDifference > 0)
            {
                int damageReductionPercentage = Math.Min(_speedDifference * 4, 40);
                _owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
            }
        }
    }
}