using Sources.Game.GamePlayLevels.Implementation.Views;

namespace Sources.Game.GamePlayLevels.Implementation.Controllers
{
    public class GamePlayLevelPresenter : IGamePlayLevelPresenter
    {
        private readonly IGamePlayLevelView _view;

        public GamePlayLevelPresenter(IGamePlayLevelView view)
        {
            _view = view;
        }
    }

    public interface IGamePlayLevelPresenter
    {
    }
}