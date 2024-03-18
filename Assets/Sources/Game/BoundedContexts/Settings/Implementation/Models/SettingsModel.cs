using Sources.Game.Common.Mvp.Implementation.Model;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Models
{
    public class SettingsModel : ObservableModel
    {
        public string Rus { get; set; }
        public string Eng { get; set; }
    }
}