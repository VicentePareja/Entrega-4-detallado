﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fire_Emblem;

public class Character
{
    [JsonPropertyName("Name")] public string Name { get; set; }
    [JsonPropertyName("Weapon")] public string Weapon { get; set; }
    [JsonPropertyName("Gender")] public string Gender { get; set; }
    [JsonPropertyName("HP")] public int MaxHP { get; set; }
    private int _currentHP;
    public int CurrentHP
    { 
        get => _currentHP; 
        set 
        { 
            _currentHP = Math.Min(Math.Max(value, 0), MaxHP);
        } 
    }
    [JsonConverter(typeof(StringToIntConverter))] [JsonPropertyName("Atk")] public int Atk { get; set; }
    [JsonConverter(typeof(StringToIntConverter))] [JsonPropertyName("Spd")] public int Spd { get; set; }
    [JsonConverter(typeof(StringToIntConverter))] [JsonPropertyName("Def")] public int Def { get; set; }
    [JsonConverter(typeof(StringToIntConverter))] [JsonPropertyName("Res")] public int Res { get; set; }
    public List<Skill> Skills { get; private set; }
    public Dictionary<string, int> TemporaryBonuses { get; private set; }
    public Dictionary<string, int> TemporaryPenalties { get; private set; }
    private Dictionary<string, double> TemporaryDamageAlterations { get; set; }
    public Dictionary<string, int> TemporaryFirstAttackBonuses { get; private set; }
    public Dictionary<string, int> TemporaryFirstAttackPenalties { get; private set; }
    private Dictionary<string, double> FirstAttackDamageAlterations { get; set; }
    public Dictionary<string, int> TemporaryFollowUpBonuses { get; private set; }
    public Dictionary<string, int> TemporaryFollowUpPenalties { get; private set; }
    private Dictionary<string, double> FollowUpDamageAlterations { get; set; }
    public Dictionary<string, double> DamageReduced { get; private set; }
    public int FollowUpGarantization { get; set; }
    public int FollowUpNegation { get; set; }
    public int NegationOfFollowUpGarantization { get; set; }
    public int NegationOfNegationOfFollowUp { get; set; }
    private double HealingEachAttackPercentage;
    private int _damageBeforeCombat;
    private int _damageAfterCombat;
    public int pushBonus { get; set; }
    public bool AreAtkBonusesEnabled { get; set; } = true;
    public bool AreDefBonusesEnabled { get; set; } = true;
    public bool AreResBonusesEnabled { get; set; } = true;
    public bool AreSpdBonusesEnabled { get; set; } = true;
    public bool AreAtkPenaltiesEnabled { get; set; } = true;
    public bool AreDefPenaltiesEnabled { get; set; } = true;
    public bool AreResPenaltiesEnabled { get; set; } = true;
    public bool AreSpdPenaltiesEnabled { get; set; } = true;
    public bool IsCounterAttackEnabled { get; set; } = true;
    private bool IsAttacker { get; set; } = false;
    
    private bool _hasAttacked { get; set; } = false;
    
    private bool _pushActive { get; set; } = false;
    public bool IsNegationOfCounterAttackNegation { get; set; } = false;
    public Character()
    {
        Skills = new List<Skill>();
        TemporaryBonuses = new Dictionary<string, int>();
        TemporaryPenalties = new Dictionary<string, int>();
        TemporaryDamageAlterations = new Dictionary<string, double>();
        TemporaryFirstAttackBonuses = new Dictionary<string, int>();
        TemporaryFirstAttackPenalties = new Dictionary<string, int>();
        FirstAttackDamageAlterations = new Dictionary<string, double>();
        TemporaryFollowUpBonuses = new Dictionary<string, int>();
        TemporaryFollowUpPenalties = new Dictionary<string, int>();
        FollowUpDamageAlterations = new Dictionary<string, double>();
        DamageReduced = new Dictionary<string, double>();
        HealingEachAttackPercentage = 0.0;
        _damageAfterCombat = 0;
        _damageBeforeCombat = 0;

    }

    public int GetEffectiveAttribute(string attribute)
    {
        int baseValue = GetBaseAttributeValue(attribute);
        return baseValue + GetTotalAttributeAdjustment(attribute, TemporaryBonuses, TemporaryPenalties);
    }
    public void AddSkill(Skill skill)
    {
        Skills.Add(skill);
    }
    
    public int GetFirstAttackAttribute(string attribute)
    {
        int baseValue = GetBaseAttributeValue(attribute);
        int totalAdjustment = GetTotalAttributeAdjustment(attribute, TemporaryBonuses, TemporaryPenalties);
        totalAdjustment += GetTotalAttributeAdjustment(attribute, 
            TemporaryFirstAttackBonuses, TemporaryFirstAttackPenalties);
        int totalDamage = baseValue + totalAdjustment;
        return totalDamage;
    }
    
    public double GetTemporaryDamageAlteration(string attribute)
    {
        double bothAttack = TemporaryDamageAlterations.ContainsKey(attribute) ?
            TemporaryDamageAlterations[attribute] : 0.0;
        return bothAttack;
    }
    
    public double GetFirstAttackDamageAlteration(string attribute)
    {
        double firstAttack = FirstAttackDamageAlterations.ContainsKey(attribute) ?
            FirstAttackDamageAlterations[attribute] : 0.0;
        double bothAttack = TemporaryDamageAlterations.ContainsKey(attribute) ?
            TemporaryDamageAlterations[attribute] : 0.0;
        return firstAttack + bothAttack;
    }
    
    public double GetFollowUpDamageAlteration(string attribute)
    {
        double followUp = FollowUpDamageAlterations.ContainsKey(attribute) ?
            FollowUpDamageAlterations[attribute] : 0.0;
        double bothAttack = TemporaryDamageAlterations.ContainsKey(attribute) ?
            TemporaryDamageAlterations[attribute] : 0.0;
        return followUp + bothAttack;
    }

    public int GetFollowUpAttribute(string attribute)
    {
        int baseValue = GetBaseAttributeValue(attribute);
        int totalAdjustment = GetTotalAttributeAdjustment(attribute, TemporaryBonuses, TemporaryPenalties);
        totalAdjustment += GetTotalAttributeAdjustment(attribute, TemporaryFollowUpBonuses, TemporaryFollowUpPenalties);
        return baseValue + totalAdjustment;
    }

    public int GetBaseAttributeValue(string attribute)
    {
        return attribute switch {
            "Atk" => Atk,
            "Spd" => Spd,
            "Def" => Def,
            "Res" => Res,
            _ => throw new ArgumentException($"Unknown attribute: {attribute}")
        };
    }
    
    public double GetHealingEachAttackPercentage()
    {
        return HealingEachAttackPercentage;
    }

    public bool GetNegationOfCounterAttackNegation()
    {
        return IsNegationOfCounterAttackNegation;
    }
    
    public string GetWeaponType()
    {
        return Weapon;
    }


    public void DisableAllBonuses()
    {
        AreAtkBonusesEnabled = false;
        AreDefBonusesEnabled = false;
        AreResBonusesEnabled = false;
        AreSpdBonusesEnabled = false;
    }
    
    public void DisableAllPenalties()
    {
        AreAtkPenaltiesEnabled = false;
        AreDefPenaltiesEnabled = false;
        AreResPenaltiesEnabled = false;
        AreSpdPenaltiesEnabled = false;
    }

    public void ReEnableBonuses()
    {
        AreAtkBonusesEnabled = true;
        AreDefBonusesEnabled = true;
        AreResBonusesEnabled = true;
        AreSpdBonusesEnabled = true;
    }

    public void ReEnablePenalties()
    {
        AreAtkPenaltiesEnabled = true;
        AreDefPenaltiesEnabled = true;
        AreResPenaltiesEnabled = true;
        AreSpdPenaltiesEnabled = true;

    }
    
    public void AddTemporaryBonus(string attribute, int value)
    {
        AddToAttributeDictionary(TemporaryBonuses, attribute, value);
    }

    public void AddTemporaryPenalty(string attribute, int value)
    {
        AddToAttributeDictionary(TemporaryPenalties, attribute, value);
    }

    public void AddTemporaryFirstAttackBonuses(string attribute, int value)
    {
        AddToAttributeDictionary(TemporaryFirstAttackBonuses, attribute, value);
    }
    
    public void AddTemporaryFirstAttackPenalties(string attribute, int value)
    {
        AddToAttributeDictionary(TemporaryFirstAttackPenalties, attribute, value);
    }
    
    public void AddTemporaryFollowUpBonuses(string attribute, int value)
    {
        AddToAttributeDictionary(TemporaryFollowUpBonuses, attribute, value);
    }
    
    public void AddTemporaryFollowUpPenalties(string attribute, int value)
    {
        AddToAttributeDictionary(TemporaryFollowUpPenalties, attribute, value);
    }
    
    public void MultiplyFirstAttackDamageAlterations(string attribute, int value)
    {
        MultiplyToAttributeDictionary(FirstAttackDamageAlterations, attribute, value);
    }

    public void MultiplyTemporaryDamageAlterations(string attribute, int value)
    {
        MultiplyToAttributeDictionary(TemporaryDamageAlterations, attribute, value);
    }
    
    public void MultiplyFollowUpDamageAlterations(string attribute, int value)
    {
        MultiplyToAttributeDictionary(FollowUpDamageAlterations, attribute, value);
    }
    
    public void AddTemporaryDamageAlteration(string attribute, double value)
    {
        if (TemporaryDamageAlterations.ContainsKey(attribute))
            TemporaryDamageAlterations[attribute] += value;
        else
            TemporaryDamageAlterations.Add(attribute, value);
    }
    
    public void AddFirstAttackDamageAlteration(string attribute, double value)
    {
        if (FirstAttackDamageAlterations.ContainsKey(attribute))
            FirstAttackDamageAlterations[attribute] += value;
        else
            FirstAttackDamageAlterations.Add(attribute, value);
    }
    
    public void AddFollowUpDamageAlteration(string attribute, double value)
    {
        if (FollowUpDamageAlterations.ContainsKey(attribute))
            FollowUpDamageAlterations[attribute] += value;
        else
            FollowUpDamageAlterations.Add(attribute, value);
    }
    
    public void CleanBonuses()
    {
        TemporaryBonuses.Clear();
    }

    public void CleanFirstAttackBonuses()
    {
        TemporaryFirstAttackBonuses.Clear();
    }

    public void CleanFollowUpBonuses()
    {
        TemporaryFollowUpBonuses.Clear();
    }
    public void CleanPenalties()
    {
        TemporaryPenalties.Clear();
    }
    public void CleanFirstAttackPenalties()
    {
        TemporaryFirstAttackPenalties.Clear();
    }
    
    public void CleanFollowUpPenalties()
    {
        TemporaryFollowUpPenalties.Clear();
    }
    
    public void CleanFirstAttackDamageAlterations()
    {
        FirstAttackDamageAlterations.Clear();
    }

    public void CleanTemporaryDamageAlterations()
    {
        TemporaryDamageAlterations.Clear();
    }
    
    public void CleanFollowUpDamageAlterations()
    {
        FollowUpDamageAlterations.Clear();
    }
    
    public bool CanCounterAttack()
    {
        return IsCounterAttackEnabled || IsNegationOfCounterAttackNegation;
    }
    
    public void DisableCounterAttack()
    {
        IsCounterAttackEnabled = false;
    }
    
    public void ReEnableCounterAttack()
    {
        IsCounterAttackEnabled = true;
    }
    
    public void DisableNegationOfCounterAttackNegation()
    {
        IsNegationOfCounterAttackNegation = false;
    }
    
    public void EnableNegationOfCounterAttackNegation()
    {
        IsNegationOfCounterAttackNegation = true;
    }

    public void SetAsAttacker()
    {
        IsAttacker = true;
    }

    public void SetAsDefender()
    {
        IsAttacker = false;
    }
    
    public bool IsAttacking()
    {
        return IsAttacker;
    }

    public bool IsCounterAttackNegated()
    {
        return !IsCounterAttackEnabled;
    }
    
    public void ResetHealingEachAttackPercentage()
    {
        HealingEachAttackPercentage = 0.0;
    }
    
    public void AddHealingEachAttackPercentage(double value)
    {
        HealingEachAttackPercentage += value;
    }
    
    public void AddHealth(int value)
    {
        if (CurrentHP + value > MaxHP)
        {
            CurrentHP = MaxHP;
        }
        else if (CurrentHP + value < 0)
        {
            CurrentHP = 0;
        }
        else
        {
            CurrentHP += value;
        }
    }
    
    public void AddDamageBeforeCombat(int value)
    {
        _damageBeforeCombat += value;
    }

    public void AddDamageAfterCombat(int value)
    {
        _damageAfterCombat += value;
    }
    
    public void CleanDamageBeforeCombat()
    {
        _damageBeforeCombat = 0;
    }
    
    public void CleanDamageAfterCombat()
    {
        _damageAfterCombat = 0;
    }
    
    public int GetDamageBeforeCombat()
    {
        return _damageBeforeCombat;
    }
    
    public int GetDamageAfterCombat()
    {
        return _damageAfterCombat;
    }
    public bool GetHasAttacked()
    {
        return _hasAttacked;
    }
    
    public void SetHasAttacked()
    {
        _hasAttacked = true;
    }
    public void CleanHasAttacked()
    {
        _hasAttacked = false;
    }
    
    public void SetPushActive()
    {
        _pushActive = true;
    }
    public bool GetPushSkills()
    {
        return _pushActive;
    }
    public void CleanPushSkills()
    {
        _pushActive = false;
        pushBonus = 0;
    }
    
    public void CleanFollowUpSkills()
    {
        FollowUpGarantization = 0;
        FollowUpNegation = 0;
        NegationOfFollowUpGarantization = 0;
        NegationOfNegationOfFollowUp = 0;
    }
    
    private void AddToAttributeDictionary(Dictionary<string, int> dictionary, string attribute, int value)
    {
        if (dictionary.ContainsKey(attribute))
            dictionary[attribute] += value;
        else
            dictionary.Add(attribute, value);
    }
    
    private void MultiplyToAttributeDictionary(Dictionary<string, double> dictionary, string attribute, int value)
    {
        if (dictionary.ContainsKey(attribute))
            dictionary[attribute] = 100 - ((100 - dictionary[attribute]) * (100 - value))/100;
        
        else
            dictionary.Add(attribute, value);
    }
    private int GetTotalAttributeAdjustment(string attribute, Dictionary<string, int> bonuses, Dictionary<string, int> penalties)
    {
        int bonus = GetAttributeAdjustment(attribute, bonuses, GetBonusEnabledFlag(attribute));
        int penalty = GetAttributeAdjustment(attribute, penalties, GetPenaltyEnabledFlag(attribute));
        return bonus + penalty;
    }

    private int GetAttributeAdjustment(string attribute, Dictionary<string, int> adjustments, bool isEnabled)
    {
        return isEnabled && adjustments.ContainsKey(attribute) ? adjustments[attribute] : 0;
    }

    private bool GetBonusEnabledFlag(string attribute)
    {
        return attribute switch {
            "Atk" => AreAtkBonusesEnabled,
            "Spd" => AreSpdBonusesEnabled,
            "Def" => AreDefBonusesEnabled,
            "Res" => AreResBonusesEnabled,
            _ => true
        };
    }

    private bool GetPenaltyEnabledFlag(string attribute)
    {
        return attribute switch {
            "Atk" => AreAtkPenaltiesEnabled,
            "Spd" => AreSpdPenaltiesEnabled,
            "Def" => AreDefPenaltiesEnabled,
            "Res" => AreResPenaltiesEnabled,
            _ => true
        };
    }
}
