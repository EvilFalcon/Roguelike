using Sources.Game.BoundedContexts.Players.Interfaces;
using Newtonsoft.Json;

namespace Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerModelFactories
{
    public class PlayerFactory
    {
        public IPlayer Create() =>
            new Player();
    }
}