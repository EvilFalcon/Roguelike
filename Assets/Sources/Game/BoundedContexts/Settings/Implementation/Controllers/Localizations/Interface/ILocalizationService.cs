using Sources.Game.BoundedContexts.Settings.Implementation.Controllers.Localizations.Implementation.Models;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Controllers.Localizations.Interface
{
    public interface ILocalizationService
    {
        public LocalizationModel Localization { get; }
        void SetLanguage(string language);
    }
}