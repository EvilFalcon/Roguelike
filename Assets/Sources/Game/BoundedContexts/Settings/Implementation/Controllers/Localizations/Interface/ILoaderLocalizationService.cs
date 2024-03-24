using Sources.Game.BoundedContexts.Settings.Implementation.Controllers.Localizations.Implementation.Models;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Controllers.Localizations.Interface
{
    public interface ILoaderLocalizationService
    {
        LocalizationModel LoadLocalizationModel(string language = "English");
    }
}