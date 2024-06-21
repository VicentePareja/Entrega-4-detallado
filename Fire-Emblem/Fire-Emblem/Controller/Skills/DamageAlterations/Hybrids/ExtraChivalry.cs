namespace Fire_Emblem {
    public class ExtraChivalry : DamageAlterationSkill {
        int _penalty;
        public ExtraChivalry(string name, string description) : base(name, description){ 
            _penalty = -5;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            Combat combat = battle.CurrentCombat;
            Character opponent = (combat._attacker == owner) ? combat._defender : combat._attacker;
            _counterTimes++;

            if (_counterTimes % 2 == 1)
            {
                if (opponent.CurrentHP >= opponent.MaxHP * 0.5)
                {
                    AddPenalties(opponent);
                }
            }

            if (_counterTimes % 2 == 0)
            {
                int hpPercentage = (int)((double)opponent.CurrentHP / opponent.MaxHP * 100);
                int damageReductionPercentage = hpPercentage / 2;
                owner.MultiplyTemporaryDamageAlterations("PercentageReduction", damageReductionPercentage);
            }
        }
        
        public void AddPenalties(Character opponent) {
            opponent.AddTemporaryPenalty("Atk", _penalty);
            opponent.AddTemporaryPenalty("Spd", _penalty);
            opponent.AddTemporaryPenalty("Def", _penalty);
        }
    }
}