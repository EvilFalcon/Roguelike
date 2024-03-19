using Sources.Game.Common.Mvp.Interfaces;

namespace Sources.Game.BoundedContexts.ViewFormServices.Interfaces
{
    public interface IFormService
    {
        void AddForm<T>(T view) where T : IView;

        void RemoveForm(string view);

        void RemoveAllForms();

        void ShowForm(string view);

        void HideForm(string view);
        void HideFormAll();
    }
}