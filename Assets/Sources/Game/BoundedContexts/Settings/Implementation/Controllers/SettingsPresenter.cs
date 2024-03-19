using System;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.Common.Mvp.Interfaces;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Controllers
{
    public class SettingsPresenter : IPresenter
    {
        private readonly SettingsModel _model;
        private readonly SettingsView _view;
        private readonly LocalizationServices _localizationServices;
        private readonly AudioServices _audioServices;
        private readonly IFormService _formService;

        public SettingsPresenter
        (
            SettingsModel model,
            SettingsView view,
            LocalizationServices services,
            AudioServices audioServices,
            IFormService formService
        )
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _localizationServices = services ?? throw new ArgumentNullException(nameof(services));
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
            _localizationServices.SetLocalization(_model.Rus);

        public void SetEngLocalization()
        {
            _localizationServices.SetLocalization(_model.Eng);
        }

        public void OnBackButtonClick()
        {
           // _formService.ShowForm<MainGameMenuView>();
           // _formService.HideForm<SettingsView>();
        }
    }
}