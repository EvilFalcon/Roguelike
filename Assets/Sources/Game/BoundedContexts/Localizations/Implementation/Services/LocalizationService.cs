using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.DataTransferObjects.Implementation.DTO.Localizations;
using Sources.Game.DataTransferObjects.Interfaces;

namespace Sources.Game.BoundedContexts.Localizations.Implementation.Services
{
    public class LocalizationService : ILoaderLocalizationService, ILocalizationService
    {
        private readonly ILoadDataFiles _loadDataFiles;
        private LocalizationModel _localization;

        public LocalizationService(ILoadDataFiles loadDataFiles)
        {
            _loadDataFiles = loadDataFiles;
        }

        public LocalizationModel Localization =>
            _localization ?? LoadLocalizationModel(); // TODO: LocalizationModel Localization { get; private set; }

        public LocalizationModel LoadLocalizationModel(string language = "English") =>
            _localization = new LocalizationModel(_loadDataFiles.LoadData(new LocalizationData(), language));

        public void SetLanguage(string language)
        {
            if (Localization.Language == language)
                return;

            Localization.SetLocalizationData(_loadDataFiles.LoadData(new LocalizationData(), language));
        }
    }
}