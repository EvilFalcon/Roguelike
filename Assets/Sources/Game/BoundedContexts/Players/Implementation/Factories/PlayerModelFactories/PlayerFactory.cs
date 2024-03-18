using Sources.Game.BoundedContexts.Players.Implementation.LiveData;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.Players.Interfaces;

namespace Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories
{
    public class PlayerFactory
    {
        public Player Create(PlayerLiveData playerLiveData) =>
            new Player(playerLiveData);
    }
}