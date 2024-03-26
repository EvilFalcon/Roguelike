using System;
using Sources.Game.BoundedContexts.Maperis.Interfaces;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.DataTransferObjects.Implementation.DTO.Settings;
using Sources.Game.DataTransferObjects.Implementation.Services;

namespace Sources.Game.BoundedContexts.Maperis.Implementation.Settings
{
    public class SettingsProvider : ISettingsModelProvider
    {
        private readonly SaveLoadedService _saveLoadedService;
        private SettingsModel _model;

        public SettingsProvider(SaveLoadedService saveLoadService)
        {
            _saveLoadedService = saveLoadService ?? throw new ArgumentNullException(nameof(saveLoadService));
            Load();
        }

        public SettingsModel Model { get; private set; }

        private SettingsModel Load()
        {
            Model = new SettingsModel(_saveLoadedService.Load<SettingsData>(nameof(SettingsData)));
            return Model;
        }

        public void Save() =>
            _saveLoadedService.Save(nameof(SettingsData), Model.Save());
    }
}