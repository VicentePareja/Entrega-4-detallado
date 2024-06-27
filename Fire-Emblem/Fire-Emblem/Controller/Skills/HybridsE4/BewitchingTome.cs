namespace Fire_Emblem
{
    public class BewitchingTome : Skill
    {
        private Character _owner;
        private Character _opponent;
        private Combat _combat;
        private int _damagePercentage;
        private const int AdvantageDamagePercentage = 40;
        private const int NoAdvantageDamagePercentage = 20;
        private const int StatBonus = 5;
        private const int FirstAttackReduction = 30;
        private const int PostCombatHealing = 7;

        public BewitchingTome(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            SetAttributes(battle, owner);
            if (IsEligibleForEffect())
            {
                SetDamagePercentage();
                ApplyOwnerBenefits();
            }
        }

        private void SetAttributes(Battle battle, Character owner)
        {
            _owner = owner;
            _combat = battle.CurrentCombat;
            _opponent = _owner == _combat._attacker ? _combat._defender : _combat._attacker;
        }

        private bool IsEligibleForEffect()
        {
            return _owner == _combat._attacker || IsOpponentUsingBowOrMagic();
        }

        private bool IsOpponentUsingBowOrMagic()
        {
            string weaponType = _opponent.GetWeaponType();
            return weaponType == "Bow" || weaponType == "Magic";
        }

        private void SetDamagePercentage()
        {
            if (OwnerHasAdvantage() || OwnerIsFaster())
            {
                _damagePercentage = AdvantageDamagePercentage;
            }
            else
            {
                _damagePercentage = NoAdvantageDamagePercentage;
            
            }
        }

        private bool OwnerHasAdvantage()
        {
            bool isOwnerAttacker = _owner == _combat._attacker;
            bool isOwnerDefender = _owner == _combat._defender;
            bool isAdvantageAttacker = _combat._advantage == "attacker";
            bool isAdvantageDefender = _combat._advantage == "defender";
            return (isAdvantageAttacker && isOwnerAttacker) || (isAdvantageDefender && isOwnerDefender);
        }

        private bool OwnerIsFaster()
        {
            return _owner.GetEffectiveAttribute("Spd") >= _opponent.GetEffectiveAttribute("Spd");
        }

        private void ApplyOwnerBenefits()
        {
            ApplyDamageToOpponent();
            ApplyTemporaryBonusesToOwner();
            ApplySpeedBasedBonusesToOwner();
            ApplyFirstAttackDamageReduction();
            HealOwnerAfterCombat();
        }

        private void ApplyDamageToOpponent()
        {
            int damage = _damagePercentage * _opponent.GetEffectiveAttribute("Atk") / 100;
            _opponent.AddDamageBeforeCombat(damage);
        }

        private void ApplyTemporaryBonusesToOwner()
        {
            _owner.AddTemporaryBonus("Atk", StatBonus);
            _owner.AddTemporaryBonus("Spd", StatBonus);
            _owner.AddTemporaryBonus("Def", StatBonus);
            _owner.AddTemporaryBonus("Res", StatBonus);
        }

        private void ApplySpeedBasedBonusesToOwner()
        {
            int extraSpdAtk = _owner.Spd / 5;
            _owner.AddTemporaryBonus("Atk", extraSpdAtk);
            _owner.AddTemporaryBonus("Spd", extraSpdAtk);
        }

        private void ApplyFirstAttackDamageReduction()
        {
            _owner.AddFirstAttackDamageAlteration("PercentageReduction", FirstAttackReduction);
        }

        private void HealOwnerAfterCombat()
        {
            _owner.AddDamageAfterCombat(-PostCombatHealing);
        }
    }
}
