using Unity.VisualScripting.Dependencies.NCalc;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Controllers
{
    public class LocalizationServices
    {
        private string _currentLocalization;

        public LocalizationServices(string defaultLocalization = "English") //TODO: add localization
        {
            SetLocalization(defaultLocalization);
        }

        public void SetLocalization(string localization)
        {
            throw new System.NotImplementedException();
        }
    }
}