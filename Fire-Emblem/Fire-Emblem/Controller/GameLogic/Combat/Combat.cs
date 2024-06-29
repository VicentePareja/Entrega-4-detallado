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
        private bool _followUp;
        private Attack _currentAttack;

        public Combat(Character attacker, Character defender, string advantage, CombatInterface combatInterface, Battle battle)
        {
            _attacker = attacker;
            _defender = defender;
            _advantage = advantage;
            _combatInterface = combatInterface;
            _battle = battle;
            _playerSkillCleaner = new PlayerSkillCleaner();
            _skillApplier = new SkillApplier(_battle);
            _currentAttack = new Attack(_attacker, _defender, _combatInterface);
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
            PerformBeforeCombatDamage();
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
            _skillApplier.ApplyPushSkills(_attacker);
            _skillApplier.ApplyPushSkills(_defender);
            PerformAfterCombatDamage();
            _playerSkillCleaner.ClearSkills(_attacker);
            _playerSkillCleaner.ClearSkills(_defender);
            _combatInterface.PrintFinalState(_attacker, _defender);
        }

        private void PerformBeforeCombatDamage()
        {
            ChangeHealthBeforeCombate(_attacker);
            ChangeHealthBeforeCombate(_defender);
            _combatInterface.PrintBeforeCombatDamage(_attacker);
            _combatInterface.PrintBeforeCombatDamage(_defender);
        }
        
        private void ChangeHealthBeforeCombate(Character character)
        {
            if (character.CurrentHP > 0){}
            int dmg = character.GetDamageBeforeCombat();
            character.CurrentHP -= dmg;
            if (character.CurrentHP <= 0)
            {
                character.CurrentHP = 1;
            }
        }
        
        private void PerformAfterCombatDamage()
        {
            if (_attacker.CurrentHP > 0)
            {
                ChangeHealthAfterCombat(_attacker);
                _combatInterface.PrintAfterCombatDamage(_attacker);
            }
            if (_defender.CurrentHP > 0)
            {
                ChangeHealthAfterCombat(_defender);
                _combatInterface.PrintAfterCombatDamage(_defender); 
            }
            
        }
        
        private void ChangeHealthAfterCombat(Character character)
        {
            {
                int dmg = character.GetDamageAfterCombat();
                character.CurrentHP -= dmg;
                if (character.CurrentHP <= 0)
                {
                    character.CurrentHP = 1;
                }
            }
        }
        private void PerformInitialAttack()
        {
            _currentAttack.PerformAttack(_advantage);
            _attacker.SetHasAttacked();
        }

        private void PerformCounterAttack()
        {
            if (_defender.CurrentHP > 0)
            {
                _currentAttack.PerformCounterAttack(_advantage);
                _defender.SetHasAttacked();
            }
        }

        private void PerformFollowUp()
        {
            if (CharactersAreAlive())
            {
                _followUp = false;
                if (IsFollowUpAttacker())
                {
                    PerformFollowUpAttacker();
                }
                if (IsFollowUpDefender())
                {
                    PerformFollowUpDefender();
                }
                if(!_followUp)
                {
                    PerformNoFollowUp();
                }
            }
        }
        
        private void PerformFollowUpAttacker()
        {
            _currentAttack.PerformFollowUpAttacker(_advantage);
            _attacker.SetHasAttacked();
            _followUp = true;
        }
        
        private void PerformFollowUpDefender()
        {
            _currentAttack.PerformFollowUpDefender(_advantage);
            _defender.SetHasAttacked();
            _followUp = true;
        }
        
        private bool CharactersAreAlive()
        {
            return _attacker.CurrentHP > 0 && _defender.CurrentHP > 0;
        }

        private bool IsFollowUpAttacker()
        {
            bool speedEnough = _attacker.GetEffectiveAttribute("Spd") >= _defender.GetEffectiveAttribute("Spd") + 5;
            bool garantiedFollowUp = _attacker.FollowUpGarantization >= 1;
            return speedEnough || garantiedFollowUp;
        }

        private bool IsFollowUpDefender()
        {
            bool speedEnough = _defender.GetEffectiveAttribute("Spd") >= _attacker.GetEffectiveAttribute("Spd") + 5;
            bool canCounter = _defender.CanCounterAttack();
            bool garantiedFollowUp = _defender.FollowUpGarantization >= 1;
            return (speedEnough || garantiedFollowUp) && canCounter;
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
