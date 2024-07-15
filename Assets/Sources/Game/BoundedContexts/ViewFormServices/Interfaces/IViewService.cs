using Sources.Game.IDontCno;

namespace Sources.Game.BoundedContexts.ViewFormServices.Interfaces
{
    public interface IViewService
    {
        void RegisterForm<T>(T view) where T : IView;

        void UnRegisterForm(string view);

        void UnRegisterAll();

        void ShowForm(string view);

        void HideForm(string view);
        void HideFormAll();
    }
}