﻿using System.Collections.Generic;
using Sources.Game.Common.Models;
using Sources.Game.DataTransferObjects.Implementation.DTO.Localizations;

namespace Sources.Game.BoundedContexts.Localizations.Implementation.Models
{
    public class LocalizationModel : ObservableModel
    {
        private IReadOnlyDictionary<string, string> _mainMenu;
        private IReadOnlyDictionary<string, string> _settingsMenu;
        private string _language;

        public LocalizationModel(LocalizationData localizationData)
        {
            MainMenu = localizationData.MainMenu;
            SettingsMenu = localizationData.SettingsMenu;
            _language = localizationData.CurrentLanguage;
        }

        public string Language
        {
            get => _language;
            private set => TrySetField(ref _language, value);
        }

        public IReadOnlyDictionary<string, string> MainMenu { get; private set; }

        public IReadOnlyDictionary<string, string> SettingsMenu { get; private set; }
        public IReadOnlyDictionary<string, string> UpgradablePlayerStats { get; private set; }

        public void SetLocalizationData(LocalizationData localizationData)
        {
            MainMenu = localizationData.MainMenu;
            SettingsMenu = localizationData.SettingsMenu;
            UpgradablePlayerStats = localizationData.UpgradablePlayerStats;
            Language = localizationData.CurrentLanguage;
        }
    }
}