using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.DataTransferObjects.Implementation.DTO.Localizations;
using Sources.Game.DataTransferObjects.Interfaces;

namespace Sources.Game.BoundedContexts.Localizations.Implementation.Services
{
    public class LocalizationService : ILoaderLocalizationService,ILocalizationService
    {
        private readonly ILoadDataFiles _loadDataFiles;

        public LocalizationService(ILoadDataFiles loadDataFiles)
        {
            _loadDataFiles = loadDataFiles;
        }

        public LocalizationModel CurrentLanguage { get; private set; }

        public LocalizationModel LoadLocalizationModel(string language = "English") =>
            CurrentLanguage = new LocalizationModel(_loadDataFiles.LoadData(new LocalizationData(), language));

        public void SetLanguage(string language)
        {
            if (CurrentLanguage.CurrentLanguage == language)
            {
                CurrentLanguage = new LocalizationModel(_loadDataFiles.LoadData(new LocalizationData(), language));
            }
            
            CurrentLanguage.SetLocalizationData(_loadDataFiles.LoadData(new LocalizationData(), language));
        }
    }
}