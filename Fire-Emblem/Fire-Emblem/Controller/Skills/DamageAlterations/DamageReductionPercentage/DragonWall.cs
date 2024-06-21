namespace Fire_Emblem 
{
    public class DragonWall : DamageAlterationSkill 
    {
        private Combat _combat;
        private Character _opponent;
        private Character _owner;
        private int _resistanceDifference;
        public DragonWall(string name, string description) : base(name, description) {}

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
            _resistanceDifference = _owner.GetEffectiveAttribute("Res") - _opponent.GetEffectiveAttribute("Res");
        }
        
        private void ApplyDamageEffect() 
        {
            if (_resistanceDifference > 0) 
            {
                int damageReductionPercentage = Math.Min(_resistanceDifference * 4, 40);
                _owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
            }
        }
    }
}