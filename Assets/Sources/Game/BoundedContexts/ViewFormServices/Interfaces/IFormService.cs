using Sources.Game.Common.Mvp.Interfaces;

namespace Sources.Game.BoundedContexts.ViewFormServices.Interfaces
{
    public interface IFormService
    {
        void AddForm<T>(T view) where T : IView;

        void RemoveForm<T>() where T : IView;

        void RemoveAllForms();

        void ShowForm<T>() where T : IView;

        void HideForm<T>() where T : IView;
    }
}