using Sources.Game.BoundedContexts.Settings.Implementation.Controllers;
using Sources.Game.BoundedContexts.Settings.Implementation.Controllers.Localizations.Interface;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.Settings.Interfaces;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Factories.Presenters
{
    public class SettingsPresenterFactory
    {
        private readonly ILocalizationService _service;
        private readonly IAudioServices _audioServices;
        private readonly IFormService _formService;

        public SettingsPresenterFactory(
            ILocalizationService service,
            IAudioServices audioServices,
            IFormService formService)
        {
            _service = service;
            _audioServices = audioServices;
            _formService = formService;
        }

        public SettingsPresenter Create(SettingsModel model, SettingsView view) =>
            new(model, view, _service, _audioServices, _formService);
    }
}