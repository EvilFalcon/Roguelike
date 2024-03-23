using System.Collections.Generic;
using Sources.Game.Common.Mvp.Implementation.Model;
using Sources.Game.DataTransferObjects.Implementation.DTO.Localizations;

namespace Sources.Game.BoundedContexts.Localizations.Implementation.Models
{
    public class LocalizationModel : ObservableModel
    {
        private IReadOnlyDictionary<string, string> _mainMenu;
        private IReadOnlyDictionary<string, string> _settingsMenu;
        
        public string CurrentLanguage { get; private set; }

        public LocalizationModel(LocalizationData localizationData)
        {
            MainMenu = localizationData.MainMenu;
            SettingsMenu = localizationData.SettingsMenu;
        }

        public IReadOnlyDictionary<string, string> MainMenu
        {
            get => _mainMenu;
            private set => TrySetField(ref _mainMenu, value);
        }

        public IReadOnlyDictionary<string, string> SettingsMenu
        {
            get => _settingsMenu;
            private set => TrySetField(ref _settingsMenu, value);
        }


        public void SetLocalizationData(LocalizationData localizationData)
        {
            CurrentLanguage = localizationData.CurrentLanguage;
            MainMenu = localizationData.MainMenu;
            SettingsMenu = localizationData.SettingsMenu;
        }
    }
}