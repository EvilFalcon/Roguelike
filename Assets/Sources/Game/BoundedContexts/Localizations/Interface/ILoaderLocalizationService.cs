using Sources.Game.BoundedContexts.Localizations.Implementation.Models;

namespace Sources.Game.BoundedContexts.Localizations.Interface
{
    public interface ILoaderLocalizationService
    {
        LocalizationModel LoadLocalizationModel(string language = "English");
    }
}