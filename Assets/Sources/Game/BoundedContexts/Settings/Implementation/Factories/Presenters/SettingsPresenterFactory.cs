using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.BoundedContexts.Settings.Implementation.Controllers;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.Settings.Interfaces;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Factories.Presenters
{
    public class SettingsPresenterFactory
    {
        private readonly ILocalizationService _service;
        private readonly IAudioController _audioController;
        private readonly IFormService _formService;

        public SettingsPresenterFactory(
            ILocalizationService service,
            IAudioController audioController,
            IFormService formService)
        {
            _service = service;
            _audioController = audioController;
            _formService = formService;
        }

        public SettingsPresenter Create(SettingsModel model, SettingsView view) =>
            new(model, view, _service, _audioController, _formService);
    }
}