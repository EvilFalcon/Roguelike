using System;
using Sources.Game.DataTransferObjects.Implementation.Services;

namespace Sources.Game.Common.Models
{
    public class ModelObserver
    {
        private readonly ISaveLoadedServices _saveLoadedServices;

        public ModelObserver(ISaveLoadedServices saveLoadedServices) =>
            _saveLoadedServices = saveLoadedServices;

        public void OnListen(ISaveModel model) =>
            model.ModelChanged += OnModelChanged;

        public void OnUnListen(ISaveModel model) =>
            model.ModelChanged -= OnModelChanged;

        private void OnModelChanged(object model) =>
            _saveLoadedServices.Save(model.GetType().Name, model);
    }

    public interface ISaveModel
    {
        event Action<object> ModelChanged;
        string SavedKey { get; }
    }
}