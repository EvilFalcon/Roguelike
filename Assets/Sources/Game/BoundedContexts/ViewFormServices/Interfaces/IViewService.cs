using Sources.Game.IDontCno;

namespace Sources.Game.BoundedContexts.ViewFormServices.Interfaces
{
    public interface IViewService
    {
        void AddForm<T>(T view) where T : IView;

        void RemoveForm(string view);

        void RemoveAllForms();

        void ShowForm(string view);

        void HideForm(string view);
        void HideFormAll();
    }
}