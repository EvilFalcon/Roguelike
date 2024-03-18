using System.Collections.Generic;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.Common.Mvp.Interfaces;

namespace Sources.Game.BoundedContexts.ViewFormServices.Implementation
{
    public class FormServices : IFormService
    {
        Dictionary<string, IView> _viewCollection = new Dictionary<string, IView>();

        public void AddForm<T>(T view) where T : IView =>
            _viewCollection[view.GetType().Name] = view;

        public void RemoveForm<T>() where T : IView
        {
            if (_viewCollection.ContainsKey(nameof(T)) == false)
                return;

            _viewCollection.Remove(nameof(T));
        }

        public void RemoveAllForms()
        {
            HideFormAll();
            _viewCollection.Clear();
        }

        public void ShowForm<T>() where T : IView
        {
            if (_viewCollection.ContainsKey(nameof(T)) == false)
                return;

            _viewCollection[nameof(T)].Show();
        }

        public void HideForm<T>() where T : IView
        {
            if (_viewCollection.ContainsKey(nameof(T)) == false)
                return;

            _viewCollection[nameof(T)].Hide();
        }

        public void HideFormAll()
        {
            foreach (IView view in _viewCollection.Values)
                view.Hide();
        }
    }
}