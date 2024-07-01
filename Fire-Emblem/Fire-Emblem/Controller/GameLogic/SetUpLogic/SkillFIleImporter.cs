using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Fire_Emblem;

public class SkillFileImporter
{
    private string _basePath;

    public SkillFileImporter(string basePath)
    {
        _basePath = basePath;
    }

    public List<Skill> ImportSkills()
    {
        string jsonPath = Path.Combine(_basePath, "skills.json");
        string jsonString = ReadFile(jsonPath);
        if (string.IsNullOrEmpty(jsonString)) return new List<Skill>();

        return DeserializeAndCreateSkills(jsonString);
    }

    private string ReadFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the file: {ex.Message}");
            return string.Empty;
        }
    }

    private List<Skill> DeserializeAndCreateSkills(string jsonString)
    {
        try
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Skill> loadedSkills = JsonSerializer.Deserialize<List<Skill>>(jsonString, options) ?? new List<Skill>();
            return CreateSkillsFromData(loadedSkills);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing skills: {ex.Message}");
            return new List<Skill>();
        }
    }

    private List<Skill> CreateSkillsFromData(List<Skill> loadedSkills)
    {
        var skills = new List<Skill>();
        var skillFactory = new SkillFactory();
        foreach (var loadedSkill in loadedSkills)
        {
            Skill skill = skillFactory.CreateSkill(loadedSkill.Name, loadedSkill.Description);
            skills.Add(skill);
        }
        return skills;
    }
}