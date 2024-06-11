using System;
using System.ComponentModel;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.IDontCno;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Controllers
{
    public class SettingsPresenter : IPresenter
    {
        private readonly SettingsModel _model;
        private readonly SettingsView _view;
        private readonly ILocalizationService _loaderLocalizationService;
        private readonly ISoundController _soundController;
        private readonly IMusicController _musicController;
        private readonly IViewService _viewService;
        private LocalizationModel _localizationModel;

        public SettingsPresenter
        (
            SettingsModel model,
            SettingsView view,
            ILocalizationService service,
            ISoundController audioController,
            IMusicController musicController,
            IViewService viewService
        )
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _loaderLocalizationService = service ?? throw new ArgumentNullException(nameof(service));
            _soundController = audioController ?? throw new ArgumentNullException(nameof(audioController));
            _musicController = musicController ?? throw new ArgumentNullException(nameof(musicController));
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
            _localizationModel = _loaderLocalizationService.Localization;
        }

        public void Enable()
        {
            _view.SetMusicVolume(_model.MusicVolume);
            _view.SetSoundVolume(_model.SoundEffectsVolume);
            _localizationModel.PropertyChanged += OnLocalization;
            _loaderLocalizationService.SetLanguage(_model.LocalizationMode);
            SetLocalization();
        }

        public void Disable()
        {
            _localizationModel.PropertyChanged -= OnLocalization;
        }

        public void SetMusicVolume(float value)
        {
            _model.MusicVolume = value;
            _musicController.SetMusicVolume(value);
        }

        public void SetSoundEffectsVolume(float value)
        {
            _model.SoundEffectsVolume = value;
            _soundController.SetSoundVolume(value);
        }

        public void SetRusLocalization()
        {
            _soundController.PlaySound();
            _loaderLocalizationService.SetLanguage(_model.LocalizationMode = "Russian");
        }

        public void SetEngLocalization()
        {
            _soundController.PlaySound();
            _loaderLocalizationService.SetLanguage(_model.LocalizationMode = "English");
        }

        public void OnBackButtonClick()
        {
            _soundController.PlaySound();
            _viewService.HideForm(nameof(SettingsView));
        }

        private void OnLocalization(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LocalizationModel.Language))
            {
                SetLocalization();
            }
        }

        private void SetLocalization()
        {
            _view.SetLocalizationMode
            (
                _localizationModel.SettingsMenu["MusicVolume"],
                _localizationModel.SettingsMenu["SoundEffectsVolume"],
                _localizationModel.SettingsMenu["BackButtonText"]
            );
        }
    }
}