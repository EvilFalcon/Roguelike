using System;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.Settings.Interfaces;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.Common.Mvp.Interfaces;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Controllers
{
    public class SettingsPresenter : IPresenter
    {
        private readonly SettingsModel _model;
        private readonly SettingsView _view;
        private readonly ILocalizationService _loaderLocalizationService;
        private readonly IAudioServices _audioServices;
        private readonly IFormService _formService;

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
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }

        public void SetMusicVolume(float value)
        {
            throw new NotImplementedException();
        }

        public void SetSoundEffectsVolume(float value)
        {
            throw new NotImplementedException();
        }

        public void SetRusLocalization() =>
            _loaderLocalizationService.SetLanguage("Russian");

        public void SetEngLocalization()
        {
            _loaderLocalizationService.SetLanguage(_model.LocalizationMode = "English");
        }

        public void OnBackButtonClick()
        {
            _formService.ShowForm(nameof(MainGameMenuView));
            _formService.HideForm(nameof(SettingsView));
        }
    }
}