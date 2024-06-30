namespace Fire_Emblem {
    public class DivineRecreation : DamageAlterationSkill
    {
        
        private double _nextAttackExtraDamage = 0;
        private double _baseDamage;
        private double _reduction;
        private double _extraDamage;
        private double _absoluteReduction;
        private int _firstAttackDamageReduction = 30;
        private string _advantage = "";
        private string _opponentFirstAtack = "";
        private string _ownerNextAtack = "";
        private bool _isOwnerAttacker;
        private Character _attacker;
        private Character _defender;
        private Character _opponent;
        private Character _owner;
        private Combat _combat;
        private int _penalty = -4;
        private double _healthThreshold = 0.5;
        public DivineRecreation(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);
            
            if (IsStatPenalties())
            {
                ApplyStatPenalties();
            }
            
            if (IsDamageAlteration())
            {
                ApplyDamageAlterations();
            }
        }
        
        private void SetAttributes(Battle battle, Character owner)
        {
            _counterTimes++;
            _owner = owner;
            _combat = battle.CurrentCombat;
            _advantage = _combat._advantage;
            _attacker = _combat._attacker;
            _defender = _combat._defender;
            _opponent = DetermineOpponent();
            _isOwnerAttacker = _attacker == owner;
        }
        
        private bool IsStatPenalties()
        {
            return _opponent.CurrentHP >= _opponent.MaxHP * _healthThreshold && _counterTimes % 2 == 1;
        }
        
        private void ApplyStatPenalties()
        {
            _opponent.AddTemporaryPenalty("Atk", _penalty);
            _opponent.AddTemporaryPenalty("Spd", _penalty);
            _opponent.AddTemporaryPenalty("Def", _penalty);
            _opponent.AddTemporaryPenalty("Res", _penalty);
        }
        
        private bool IsDamageAlteration()
        {
            return _opponent.CurrentHP >= _opponent.MaxHP * _healthThreshold && _counterTimes % 2 == 0;
        }
        
        private void ApplyDamageAlterations()
        {
            SetAttackOrder();
            double withOutReductionDamage = CalculateDamageOpponentWithOutReduction();
            _owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", _firstAttackDamageReduction);
            double reducedDamage = CalculateDamageOpponentWithReduction();
            double damageDifference = withOutReductionDamage - reducedDamage;
            SetExtraDamage(damageDifference);
        }
        
        private void SetAttackOrder()
        {
            if (_isOwnerAttacker)
            {
                _opponentFirstAtack = "CounterAttack";
                _ownerNextAtack = "FollowUpAttacker";
            }
            else
            {
                _opponentFirstAtack = "Attack";
                _ownerNextAtack = "CounterAttack";

            }
        }
        
        private double CalculateDamageOpponentWithOutReduction()
        {
            if (_opponentFirstAtack == "CounterAttack")
            {
                return (double)PerformCounterAttack(_advantage);
            }
            else
            {
                return (double)PerformAttack(_advantage);
            }
        }

        private double CalculateDamageOpponentWithReduction()
        {
            if (_opponentFirstAtack == "CounterAttack")
            {
                return (double)PerformCounterAttack(_advantage);
            }
            else
            {
                return (double)PerformAttack(_advantage);
            }
        }

        private void SetExtraDamage(double damageDifference)
        {
            _nextAttackExtraDamage = damageDifference;

            if (_ownerNextAtack == "FollowUpAttacker")
            {
                _owner.AddFollowUpDamageAlteration("ExtraDamage", _nextAttackExtraDamage);
            }
            else if (_opponentFirstAtack == "CounterAttack")
            {
                _owner.AddFirstAttackDamageAlteration("ExtraDamage", _nextAttackExtraDamage);
            }
        }
        
        private Character DetermineOpponent()
        {
            return (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
        }
        
        private int PerformCounterAttack(string advantage)
        {
            double weaponTriangleBonus = advantage == "defensor" ? 1.2 : advantage == "atacante" ? 0.8 : 1.0;
            int defenderAtk = _defender.GetFirstAttackAttribute("Atk");
            int attackerDef = _attacker.GetFirstAttackAttribute(_defender.Weapon == "Magic" ? "Res" : "Def");
            _baseDamage = Math.Max((int)((defenderAtk * weaponTriangleBonus) - attackerDef), 0);
            _reduction = _attacker.GetFirstAttackDamageAlteration("PercentageReduction");
            _extraDamage = _defender.GetFirstAttackDamageAlteration("ExtraDamage");
            _absoluteReduction = _attacker.GetFirstAttackDamageAlteration("AbsoluteReduction");
            return CalculateDamage();
        }
        
        private int PerformAttack(string advantage)
        {
            double weaponTriangleBonus = advantage == "atacante" ? 1.2 : advantage == "defensor" ? 0.8 : 1.0;
            int attackerAtk = _attacker.GetFirstAttackAttribute("Atk");
            int defenderDef = _defender.GetFirstAttackAttribute(_attacker.Weapon == "Magic" ? "Res" : "Def");
            _baseDamage = Math.Max((int)((attackerAtk * weaponTriangleBonus) - defenderDef), 0);
            _reduction = _defender.GetFirstAttackDamageAlteration("PercentageReduction");
            _extraDamage = _attacker.GetFirstAttackDamageAlteration("ExtraDamage");
            _absoluteReduction = _defender.GetFirstAttackDamageAlteration("AbsoluteReduction");
            return CalculateDamage();
        }

        private int CalculateDamage()
        {
            double initialDamage = (double)_baseDamage;
            double newDamage = initialDamage + _extraDamage;
            double damageReduced = newDamage * (100.0 - _reduction) / 100.0;
            damageReduced = Math.Round(damageReduced, 9);
            return Math.Max(Convert.ToInt32(Math.Floor(damageReduced)) + Convert.ToInt32(_absoluteReduction), 0);
        }
    }
}