using System;

namespace Fire_Emblem
{
    public class Dodge : DamageAlterationSkill
    {
        public Dodge(string name, string description) : base(name, description) {}

        public override void ApplyEffect(Battle battle, Character owner)
        {
            _counterTimes++;
            if (_counterTimes % 2 == 0)
            {
                Combat combat = battle.CurrentCombat;
                Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;
                int speedDifference = owner.GetEffectiveAttribute("Spd") - opponent.GetEffectiveAttribute("Spd");
                if (speedDifference > 0)
                {
                    int damageReductionPercentage = Math.Min(speedDifference * 4, 40);
                    owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
                }
            }
        }
    }
}