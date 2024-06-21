using Fire_Emblem_View;

namespace Fire_Emblem
{
    public class Combat
    {
        public readonly Character _attacker;
        public readonly Character _defender;
        public readonly string _advantage;
        private readonly CombatInterface _combatInterface;
        private readonly Battle _battle;
        private readonly PlayerSkillCleaner _playerSkillCleaner;
        private readonly SkillApplier _skillApplier;

        public Combat(Character attacker, Character defender, string advantage, CombatInterface combatInterface, Battle battle)
        {
            _attacker = attacker;
            _defender = defender;
            _advantage = advantage;
            _combatInterface = combatInterface;
            _battle = battle;
            _playerSkillCleaner = new PlayerSkillCleaner();
            _skillApplier = new SkillApplier(_battle);
        }

        public void Start()
        {
            PrepareCombat();
            ExecuteCombat();
            FinalizeCombat();
        }

        private void PrepareCombat()
        {
            _attacker.SetAsAttacker();
            _defender.SetAsDefender();
            _skillApplier.ApplySkills(_attacker, _defender);
            _combatInterface.PrintSkills(_attacker);
            _combatInterface.PrintSkills(_defender);
        }

        private void ExecuteCombat()
        {
            PerformInitialAttack();
            if (_defender.CurrentHP > 0)
            {
                PerformCounterAttack();
            }
            if (_attacker.CurrentHP > 0 && _defender.CurrentHP > 0)
            {
                PerformFollowUp();
            }
        }
        
        private void FinalizeCombat()
        {
            _playerSkillCleaner.ClearSkills(_attacker);
            _playerSkillCleaner.ClearSkills(_defender);
            _combatInterface.PrintFinalState(_attacker, _defender);
        }
        private void PerformInitialAttack()
        {
            Attack attack = new Attack(_attacker, _defender, _combatInterface);
            attack.PerformAttack(_advantage);
        }

        private void PerformCounterAttack()
        {
            if (_defender.CurrentHP > 0)
            {
                Attack counterAttack = new Attack(_attacker, _defender, _combatInterface);
                counterAttack.PerformCounterAttack(_advantage);
            }
        }

        private void PerformFollowUp()
        {
            if (_attacker.CurrentHP > 0 && _defender.CurrentHP > 0)
            {
                Attack followUpAttack = new Attack(_attacker, _defender, _combatInterface);
                if (IsFollowUpAttacker())
                {
                    followUpAttack.PerformFollowUpAttacker(_advantage);
                }
                else if (IsFollowUpDefender())
                {
                    followUpAttack.PerformFollowUpDefender(_advantage);
                }
                else
                {
                    PerformNoFollowUp();
                }
            }
        }

        private bool IsFollowUpAttacker()
        {
            bool speedEnough = _attacker.GetEffectiveAttribute("Spd") >= _defender.GetEffectiveAttribute("Spd") + 5;
            return speedEnough;
        }

        private bool IsFollowUpDefender()
        {
            bool speedEnough = _defender.GetEffectiveAttribute("Spd") >= _attacker.GetEffectiveAttribute("Spd") + 5;
            bool canCounter = _defender.CanCounterAttack();
            return speedEnough && canCounter;
        }

        private void PerformNoFollowUp()
        {
            if (!_defender.CanCounterAttack())
            {
                _combatInterface.PrintNoFollowUpNoCounterAttack(_attacker);
            }
            else
            {
                _combatInterface.PrintNoFollowUp();
            }
        }
        
    }
}
