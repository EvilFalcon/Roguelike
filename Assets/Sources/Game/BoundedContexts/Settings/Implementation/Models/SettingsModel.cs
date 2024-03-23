using Sources.Game.Common.Mvp.Implementation.Model;
using Sources.Game.DataTransferObjects.Implementation.DTO;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Models
{
    public class SettingsModel : ObservableModel
    {
        private string _localizationMode;
        private float _musicVolume;
        private float _soundEffectsVolume;

        public SettingsModel(SettingsData settingsData)
        {
            LocalizationMode = settingsData.LocalizationMode;
            MusicVolume = settingsData.MusicVolume;
            SoundEffectsVolume = settingsData.SoundEffectsVolume;
        }

        public string LocalizationMode
        {
            get => _localizationMode;
            set => TrySetField(ref _localizationMode, value);
        }

        public float MusicVolume
        {
            get => _musicVolume;
            set => TrySetField(ref _musicVolume, value);
        }

        public float SoundEffectsVolume
        {
            get => _soundEffectsVolume;
            set => TrySetField(ref _musicVolume, value);
        }
    }
}