namespace Fire_Emblem {
    public class LaguzFriend : DamageAlterationSkill
    {

        private Character _owner;
        private Combat _combat;
        private Character _opponent;
        private double _penaltyPonderator = 0.5;

        public LaguzFriend(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);
            
            if (IsDamageAlterationApplicable())
            {
                ApplyDamageAlterations();
            }

            if (IsStatPenaltyApplicable())
            {
                ApplyStatPenalties();
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
            _owner.MultiplyTemporaryDamageAlterations("PercentageReduction", 50);
            _owner.AreDefBonusesEnabled = false;
            _owner.AreResBonusesEnabled = false;
        }
        
        private bool IsStatPenaltyApplicable()
        {
            return _counterTimes % 2 == 1;
        }
        
        private void ApplyStatPenalties()
        {
            int defPenalty = -(int)(_owner.GetBaseAttributeValue("Def") * _penaltyPonderator);
            int resPenalty = -(int)(_owner.GetBaseAttributeValue("Res") * _penaltyPonderator);
            _owner.AddTemporaryPenalty("Def", defPenalty);
            _owner.AddTemporaryPenalty("Res", resPenalty);
        }
    }
}