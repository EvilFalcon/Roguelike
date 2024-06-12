using Sources.Game.Common.Mvp;
using Sources.Game.IDontCno;

namespace Sources.Game.GamePlayLevels.Implementation.Views
{
    public class GamePlayLevelView : ViewBase, IGamePlayLevelView

    {
        protected override void Enable()
        {
            throw new System.NotImplementedException();
        }

        protected override void Disable()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IGamePlayLevelView : IView
    {
    }
}