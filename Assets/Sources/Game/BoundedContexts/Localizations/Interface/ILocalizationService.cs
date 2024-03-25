using Sources.Game.BoundedContexts.Localizations.Implementation.Models;

namespace Sources.Game.BoundedContexts.Localizations.Interface
{
    public interface ILocalizationService
    {
        public LocalizationModel Localization { get; }
        void SetLanguage(string language);
    }
}