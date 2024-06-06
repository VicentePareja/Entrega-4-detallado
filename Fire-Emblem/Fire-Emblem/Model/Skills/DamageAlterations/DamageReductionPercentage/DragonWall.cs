namespace Fire_Emblem 
{
    public class DragonWall : DamageAlterationSkill 
    {
        public DragonWall(string name, string description) : base(name, description) {}

        public override void ApplyEffect(Battle battle, Character owner) 
        {
            _counterTimes++;
            if (_counterTimes % 2 == 0)
            {
                Combat combat = battle.CurrentCombat;
                Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;
                int resistanceDifference = owner.GetEffectiveAttribute("Res") - opponent.GetEffectiveAttribute("Res");
                if (resistanceDifference > 0)

                {
                    int damageReductionPercentage = Math.Min(resistanceDifference * 4, 40);
                    owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
                }
            }
        }
    }
}