namespace Fire_Emblem
{
    public class MasterMind : Skill
    {
        private Character _owner;
        private Character _opponent;
        private Combat _combat;

        private const int MinimumHpThreshold = 2;
        private const int DamageBeforeCombat = 1;
        private const int AttackBonus = 9;
        private const int SpeedBonus = 9;
        private const double DamageAlterationFactor = 0.8;

        public MasterMind(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);
            ApplyOwnerDamageBeforeCombat();
            if (IsOwnerAttacker())
            {
                ApplyOwnerBonuses();
                ApplyOwnerDamageAlteration();
            }
        }

        private void SetAttributes(Battle battle, Character owner)
        {
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = _owner == _combat._attacker ? _combat._defender : _combat._attacker;
        }

        private void ApplyOwnerDamageBeforeCombat()
        {
            if (_owner.CurrentHP >= MinimumHpThreshold)
            {
                _owner.AddDamageBeforeCombat(DamageBeforeCombat);
            }
        }

        private bool IsOwnerAttacker()
        {
            return _owner == _combat._attacker;
        }

        private void ApplyOwnerBonuses()
        {
            _owner.AddTemporaryBonus("Atk", AttackBonus);
            _owner.AddTemporaryBonus("Spd", SpeedBonus);
        }

        private void ApplyOwnerDamageAlteration()
        {
            int totalExtraBonus = GetTotalBonuses();
            int totalOpponentPenalties = GetTotalPenalties();
            double extraDamage = (totalExtraBonus + totalOpponentPenalties) * DamageAlterationFactor;
            _owner.AddTemporaryDamageAlteration("ExtraDamage", extraDamage);
        }

        private int GetTotalBonuses()
        {
            int total = 0;

            if (_owner.AreAtkBonusesEnabled && _owner.TemporaryBonuses.ContainsKey("Atk"))
            {
                total += _owner.TemporaryBonuses["Atk"];
            }

            if (_owner.AreSpdBonusesEnabled && _owner.TemporaryBonuses.ContainsKey("Spd"))
            {
                total += _owner.TemporaryBonuses["Spd"];
            }

            if (_owner.AreDefBonusesEnabled && _owner.TemporaryBonuses.ContainsKey("Def"))
            {
                total += _owner.TemporaryBonuses["Def"];
            }

            if (_owner.AreResBonusesEnabled && _owner.TemporaryBonuses.ContainsKey("Res"))
            {
                total += _owner.TemporaryBonuses["Res"];
            }

            return total;
        }

        private int GetTotalPenalties()
        {
            int total = 0;

            if (_opponent.AreAtkPenaltiesEnabled && _opponent.TemporaryPenalties.ContainsKey("Atk"))
            {
                total += _opponent.TemporaryPenalties["Atk"];
            }

            if (_opponent.AreSpdPenaltiesEnabled && _opponent.TemporaryPenalties.ContainsKey("Spd"))
            {
                total += _opponent.TemporaryPenalties["Spd"];
            }

            if (_opponent.AreDefPenaltiesEnabled && _opponent.TemporaryPenalties.ContainsKey("Def"))
            {
                total += _opponent.TemporaryPenalties["Def"];
            }

            if (_opponent.AreResPenaltiesEnabled && _opponent.TemporaryPenalties.ContainsKey("Res"))
            {
                total += _opponent.TemporaryPenalties["Res"];
            }

            return total;
        }
    }
}
