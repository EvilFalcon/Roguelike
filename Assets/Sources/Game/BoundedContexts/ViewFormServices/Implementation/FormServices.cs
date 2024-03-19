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

        public void RemoveForm(string view)
        {
            if (_viewCollection.ContainsKey(view) == false)
                return;

            _viewCollection.Remove(view);
        }

        public void RemoveAllForms()
        {
            HideFormAll();
            _viewCollection.Clear();
        }

        public void ShowForm(string view)
        {
            if (_viewCollection.ContainsKey(view) == false)
                return;

            _viewCollection[view].Show();
        }

        public void HideForm(string view)
        {
            if (_viewCollection.ContainsKey(view) == false)
                return;

            _viewCollection[view].Hide();
        }

        public void HideFormAll()
        {
            foreach (IView view in _viewCollection.Values)
                view.Hide();
        }
    }
}