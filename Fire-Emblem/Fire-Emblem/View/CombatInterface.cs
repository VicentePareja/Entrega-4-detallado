using Fire_Emblem_View;
namespace Fire_Emblem;

public class CombatInterface
{
    private readonly View _view;
    
    public CombatInterface(View view)
    {
        _view = view;
    }
    
    public void PrintSkills(Character character)
    {
        PrintBonuses(character);
        PrintPenalties(character);
        PrintBonusNegations(character);
        PrintPenaltyNegations(character);
        PrintDamageAlterations(character);
        PrintHealingEachAttack(character);
        PrintCounterAttackNegations(character);
        PrintFollowUpAlteratios(character);
    }

    private void PrintBonuses(Character character)
    {
        PrintTemporaryBonuses(character);
        PrintFirstAttackBonuses(character);
        PrintFollowUpBonuses(character);
    }
    
    private void PrintPenalties(Character character)
    {
        PrintTemporaryPenalties(character);
        PrintFirstAttackPenalties(character);
        PrintFollowUpPenalties(character);
    }
    
    private void PrintBonusNegations(Character character)
    {
        string[] statsOrder = { "Atk", "Spd", "Def", "Res" };
        foreach (var stat in statsOrder)
        {
            bool isBonusEnabled = stat switch {
                "Atk" => character.AreAtkBonusesEnabled,
                "Spd" => character.AreSpdBonusesEnabled,
                "Def" => character.AreDefBonusesEnabled,
                "Res" => character.AreResBonusesEnabled,
                _ => true
            };

            if (!isBonusEnabled)
            {
                _view.WriteLine($"Los bonus de {stat} de {character.Name} fueron neutralizados");
            }
        }
    }
    
    private void PrintPenaltyNegations(Character character)
    {
        string[] statsOrder = { "Atk", "Spd", "Def", "Res" };
        foreach (var stat in statsOrder)
        {
            bool isPenaltyEnabled = stat switch {
                "Atk" => character.AreAtkPenaltiesEnabled,
                "Spd" => character.AreSpdPenaltiesEnabled,
                "Def" => character.AreDefPenaltiesEnabled,
                "Res" => character.AreResPenaltiesEnabled,
                _ => true
            };

            if (!isPenaltyEnabled)
            {
                _view.WriteLine($"Los penalty de {stat} de {character.Name} fueron neutralizados");
            }
        }
    }
    
    private void PrintDamageAlterations(Character character)
    {
        PrintExtraDamage(character);
        PrintOpponentPercentageReduction(character);
        PrintAbsoluteReduction(character);
    }
    
    private void PrintHealingEachAttack(Character character)
    {
        double healing = character.GetHealingEachAttackPercentage();
        if (healing > 0)
        {
            _view.WriteLine($"{character.Name} recuperará HP igual al {healing}% del daño realizado en cada ataque");
        }
    }
    
    private void PrintCounterAttackNegations(Character character)
    {
        bool isCounterAttackNegated = character.IsCounterAttackNegated() && !character.IsAttacking();
        if (isCounterAttackNegated)
        {
            
            if (character.GetNegationOfCounterAttackNegation())
            {
                _view.WriteLine($"{character.Name} neutraliza los efectos que previenen sus contraataques");
            }
            else
            {
                _view.WriteLine($"{character.Name} no podrá contraatacar");
            }
        }
    }

    private void PrintFollowUpAlteratios(Character character)
    {
        PrintFollowGarantizations(character);
        PrintFollowUpNegations(character);
        PrintNegationOfFollowUpNegation(character);
        PrintNegationOfFollowUpGarantization(character);
    }
    
    private void PrintTemporaryBonuses(Character character)
    {
        string[] statsOrder = { "Atk", "Spd", "Def", "Res" };
        foreach (var stat in statsOrder)
        {
            int bonus = character.TemporaryBonuses.ContainsKey(stat) ? character.TemporaryBonuses[stat] : 0;
            if (bonus != 0)
            {
                _view.WriteLine($"{character.Name} obtiene {stat}{bonus:+#;-#;+0}");
            }
        }
    }

    private void PrintTemporaryPenalties(Character character)
    {
        string[] statsOrder = { "Atk", "Spd", "Def", "Res" };
        foreach (var stat in statsOrder)
        {
            int penalty = character.TemporaryPenalties.ContainsKey(stat) ? character.TemporaryPenalties[stat] : 0;
            if (penalty != 0)
            {
                _view.WriteLine($"{character.Name} obtiene {stat}{penalty:+#;-#;+0}");
            }
        }
    }
    

    private void PrintFirstAttackBonuses(Character character)
    {
        string[] statsOrder = { "Atk", "Spd", "Def", "Res" };
        foreach (var stat in statsOrder)
        {
            int bonus = character.TemporaryFirstAttackBonuses.ContainsKey(stat) ? character.TemporaryFirstAttackBonuses[stat] : 0;
            if(bonus != 0)
            {
                _view.WriteLine($"{character.Name} obtiene {stat}{bonus:+#;-#;+0} en su primer ataque");
            }
        }
    }

    private void PrintFirstAttackPenalties(Character character)
    {
        string[] statsOrder = { "Atk", "Spd", "Def", "Res" };
        foreach (var stat in statsOrder)
        {

            int penalty = character.TemporaryFirstAttackPenalties.ContainsKey(stat) ? character.TemporaryFirstAttackPenalties[stat] : 0;
            if (penalty != 0)
            {
                _view.WriteLine($"{character.Name} obtiene {stat}{penalty:+#;-#;+0} en su primer ataque");
            }
        }
    }

    private void PrintFollowUpBonuses(Character character)
    {
        string[] statsOrder = { "Atk", "Spd", "Def", "Res" };
        foreach (var stat in statsOrder)
        {
            int bonus = character.TemporaryFollowUpBonuses.ContainsKey(stat) ? character.TemporaryFollowUpBonuses[stat] : 0;
            if(bonus != 0)
            {
                _view.WriteLine($"{character.Name} obtiene {stat}{bonus:+#;-#;+0} en su Follow-Up");
            }
        }
    }

    private void PrintFollowUpPenalties(Character character)
    {
        string[] statsOrder = { "Atk", "Spd", "Def", "Res" };
        foreach (var stat in statsOrder)
        {
            int bonus = character.TemporaryFollowUpPenalties.ContainsKey(stat) ? character.TemporaryFollowUpPenalties[stat] : 0;
            if(bonus != 0)
            {
                _view.WriteLine($"{character.Name} obtiene {stat}{bonus:+#;-#;+0} en su Follow-Up");
            }
        }
    }

    private void PrintExtraDamage(Character character)
    {
        string stat = "ExtraDamage";
        double extraDamage = character.GetTemporaryDamageAlteration(stat);
        double firstAttackDamageAlteration = character.GetFirstAttackDamageAlteration(stat) - extraDamage;
        double followUpDamageAlteration = character.GetFollowUpDamageAlteration(stat) - extraDamage;
        if (extraDamage >= 1.0)
        {
            _view.WriteLine($"{character.Name} realizará +{(int)extraDamage} daño extra en cada ataque");
        }
        if (firstAttackDamageAlteration != 0.0)
        {
            _view.WriteLine($"{character.Name} realizará +{(int)firstAttackDamageAlteration} daño extra en su primer ataque");
        }
        if (followUpDamageAlteration != 0.0)
        {
            _view.WriteLine($"{character.Name} realizará +{(int)followUpDamageAlteration} daño extra en su Follow-Up");
        }
    }

    private void PrintOpponentPercentageReduction(Character character)
    {
        string stat = "PercentageReduction";
        double damageReduction = character.GetTemporaryDamageAlteration(stat);
        double firstAttackDamageReduction = character.GetFirstAttackDamageAlteration(stat) - damageReduction;
        double followUpDamageReduction = character.GetFollowUpDamageAlteration(stat) - damageReduction;
        
        if (damageReduction != 0.0)
        {
            _view.WriteLine($"{character.Name} reducirá el daño de los ataques del rival en un {damageReduction}%");
        }
        if (firstAttackDamageReduction != 0.0)
        {
            _view.WriteLine($"{character.Name} reducirá el daño del primer ataque del rival en un {firstAttackDamageReduction}%");
        }
        if (followUpDamageReduction != 0.0)
        {
            _view.WriteLine($"{character.Name} reducirá el daño del Follow-Up del rival en un {followUpDamageReduction}%");
        }
    }

    private void PrintAbsoluteReduction(Character character)
    {
        string stat = "AbsoluteReduction";
        double damageReduction = character.GetTemporaryDamageAlteration(stat);
        double firstAttackDamageReduction = character.GetFirstAttackDamageAlteration(stat) - damageReduction;
        double followUpDamageReduction = character.GetFollowUpDamageAlteration(stat) - damageReduction;
        if (damageReduction != 0.0)
        {
            _view.WriteLine($"{character.Name} recibirá {damageReduction} daño en cada ataque");
        }
        if (firstAttackDamageReduction != 0.0)
        {
            _view.WriteLine(
                $"{character.Name} reducirá el daño del primer ataque del rival en {firstAttackDamageReduction}");
        }
        if (followUpDamageReduction != 0.0)
        {
            _view.WriteLine(
                $"{character.Name} reducirá el daño de los Follow-Up del rival en {followUpDamageReduction}");
        }
    }
    
    
    public void PrintHealing(Character character, int healing)
    {
        if (healing > 0)
        {
            int currentHP = character.CurrentHP;
            _view.WriteLine($"{character.Name} recupera {healing} HP luego de atacar y queda con {currentHP} HP.");
        }
    }
    
    public void PrintNoFollowUpNoCounterAttack(Character character)
    {
        _view.WriteLine($"{character.Name} no puede hacer un follow up");
    }
    public void PrintNoFollowUp()
    {
        _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }

    public void PrintFinalState(Character attacker, Character defender)
    {
        _view.WriteLine($"{attacker.Name} ({attacker.CurrentHP}) : {defender.Name} ({defender.CurrentHP})");
    }

    public void PrintAttack(Character attacker, Character defender, int damage)
    {
        _view.WriteLine($"{attacker.Name} ataca a {defender.Name} con {damage} de daño");
    }

    public void PrintBeforeCombatDamage(Character character)
    {
        string name = character.Name;
        int currentHP = character.CurrentHP;
        int damage = character.GetDamageBeforeCombat();
        
        if (damage > 0)
        {
            _view.WriteLine($"{name} recibe {damage} de daño antes de iniciar el combate y queda con {currentHP} HP");
        }else if (damage < 0)
        {
            _view.WriteLine($"{name} recupera {-damage} HP antes de iniciar el combate y queda con {currentHP} HP");
        }
        
    }
    
    public void PrintAfterCombatDamage(Character character)
    {
        string name = character.Name;
        int currentHP = character.CurrentHP;
        int damage = character.GetDamageAfterCombat();
        
        if (damage > 0)
        {
            _view.WriteLine($"{name} recibe {damage} de daño despues del combate");
        }else if (damage < 0)
        {
            _view.WriteLine($"{name} recupera {-damage} HP despues del combate");
        }
    }
    
    private void PrintFollowGarantizations(Character character)
    {
        int followUpGarantization = character.FollowUpGarantization;
        if (followUpGarantization > 0)
        {
            _view.WriteLine($"{character.Name} tiene {followUpGarantization} efecto(s) que garantiza(n) su follow up activo(s)");
        }
    }
    private void PrintFollowUpNegations(Character character)
    {
        int followUpNegation = character.FollowUpNegation;
        if (followUpNegation > 0)
        {
            _view.WriteLine($"{character.Name} tiene {followUpNegation} efecto(s) que neutraliza(n) su follow up activo(s)");
        }
    }
    
    private void PrintNegationOfFollowUpGarantization(Character character)
    {
        if (character.NegationOfFollowUpGarantization == 1)
        {
            _view.WriteLine($"{character.Name} es inmune a los efectos que garantizan su follow up");
        }
    }
    
    private void PrintNegationOfFollowUpNegation(Character character)
    {
        if (character.NegationOfNegationOfFollowUp == 1)
        {
            _view.WriteLine($"{character.Name} es inmune a los efectos que neutralizan su follow up");
        }
    }
}