using System;
using System.ComponentModel;
using Sources.Game.BoundedContexts.Settings.Implementation.Controllers.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Controllers.Localizations.Interface;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.Settings.Interfaces;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.Common.Mvp.Interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Controllers
{
    public class SettingsPresenter : IPresenter
    {
        private readonly SettingsModel _model;
        private readonly SettingsView _view;
        private readonly ILocalizationService _loaderLocalizationService;
        private readonly IAudioServices _audioServices;
        private readonly IFormService _formService;
        private LocalizationModel _localizationModel;

        public SettingsPresenter
        (
            SettingsModel model,
            SettingsView view,
            ILocalizationService service,
            IAudioServices audioServices,
            IFormService formService
        )
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _loaderLocalizationService = service ?? throw new ArgumentNullException(nameof(service));
            _audioServices = audioServices ?? throw new ArgumentNullException(nameof(audioServices));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _localizationModel = _loaderLocalizationService.Localization;
        }

        public void Enable()
        {

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
            Debug.Log("SetMusicVolume: " + value);
        }

        public void SetSoundEffectsVolume(float value)
        {
            Debug.Log("SetSoundEffectsVolume: " + value);
        }

        public void SetRusLocalization() =>
            _loaderLocalizationService.SetLanguage(_model.LocalizationMode = "Russian");

        public void SetEngLocalization() =>
            _loaderLocalizationService.SetLanguage(_model.LocalizationMode = "English");

        public void OnBackButtonClick() =>
            _formService.HideForm(nameof(SettingsView));

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