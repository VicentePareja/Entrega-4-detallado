﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Fire_Emblem_View;

namespace Fire_Emblem
{
    public class SetUpLogic
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly string _teamsFolder;
        private readonly SetUpInterface _setUpInterface;
        private readonly SetUpController _setUpController;
        private readonly CharacterFileImporter _characterFileImporter;
        private readonly SkillFileImporter _skillFileImporter;
        private readonly TeamsValidator _teamsValidator;
        private readonly TeamChooser _teamChooser;
        public SetUpLogic(string teamsFolder, SetUpInterface setUpInterface, SetUpController setUpController, 
            Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            _setUpInterface = setUpInterface;
            _setUpController = setUpController;
            _teamsFolder = teamsFolder;
            _characterFileImporter = new CharacterFileImporter(Path.Combine(_teamsFolder, "../.."));
            _skillFileImporter = new SkillFileImporter(Path.Combine(_teamsFolder, "../.."));
            _teamsValidator = new TeamsValidator(_player1, _player2);
            _teamChooser = new TeamChooser(_player1, _player2);
        }

        public void LoadTeams(Player player1, Player player2)
        {

            ShowAvailableFiles();
            string selectedFile = SelectFile();
            ImportFiles();
            _teamsValidator.ValidateTeams(selectedFile);
            _teamChooser.ChooseTeam(selectedFile);
        }

        private void ShowAvailableFiles()
        {
            _setUpInterface.PrintGetTeamsFolder();
            var files = Directory.GetFiles(_teamsFolder, "*.txt");
            if (files.Length == 0)
            {
                _setUpInterface.PrintNotFilesInFolder();
                throw new InvalidOperationException("No hay archivos disponibles.");
            }

            for (int i = 0; i < files.Length; i++)
            {
                _setUpInterface.PrintFile(i, Path.GetFileName(files[i]));
            }
        }

        private string SelectFile()
        {
            string input = _setUpController.GetTeamsFolder();
            var files = GetTextFilesFromFolder();

            if (IsValidFileSelection(input, files, out int fileIndex))
            {
                return files[fileIndex];
            }
    
            return null;
        }
        private void ImportFiles()
        {
            TeamChooser.SetCharacters(_characterFileImporter.ImportCharacters());
            TeamChooser.SetSkills(_skillFileImporter.ImportSkills());
        }
        
        private string[] GetTextFilesFromFolder()
        {
            return Directory.GetFiles(_teamsFolder, "*.txt");
        }

        private bool IsValidFileSelection(string input, string[] files, out int fileIndex)
        {
            return int.TryParse(input, out fileIndex) && fileIndex >= 0 && fileIndex < files.Length;
        }
        
    }
}