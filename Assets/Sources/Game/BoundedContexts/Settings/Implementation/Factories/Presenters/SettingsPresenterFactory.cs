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
        private readonly ISoundController _soundController;
        private readonly IMusicController _musicController;
        private readonly IViewService _viewService;

        public SettingsPresenterFactory
        (
            ILocalizationService service,
            ISoundController soundController,
            IMusicController musicController,
            IViewService viewService
        )
        {
            _service = service;
            _soundController = soundController;
            _musicController = musicController;
            _viewService = viewService;
        }

        public SettingsPresenter Create(SettingsModel model, SettingsView view) =>
            new(model, view, _service, _soundController, _musicController, _viewService);
    }
}