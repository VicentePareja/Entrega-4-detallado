namespace Fire_Emblem 
{
    public class GoldenLotus : DamageAlterationSkill 
    {
        private Combat _combat;
        private Character _opponent;
        private Character _owner;
        private bool _isOpponentPhysical;
        public GoldenLotus(string name, string description) : base(name, description) {}

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
            _isOpponentPhysical = _opponent.Weapon != "Magic";
        }
        
        private void ApplyDamageEffect() 
        {
            if (_isOpponentPhysical) 
            {
                _owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", 50);
            }
        }
    }
}