using Sources.Game.BoundedContexts.Localizations.Implementation.Models;

namespace Sources.Game.BoundedContexts.Localizations.Interface
{
    public interface ILocalizationService
    {
        public LocalizationModel CurrentLanguage { get; }
        void SetLanguage(string language);
    }
}