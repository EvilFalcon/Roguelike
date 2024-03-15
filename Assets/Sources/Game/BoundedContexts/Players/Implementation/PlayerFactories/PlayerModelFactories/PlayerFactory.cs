using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.DataTransferObjects.Implementation.DTO.Player;

namespace Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerModelFactories
{
    public class PlayerFactory
    {
        public IPlayer Create(PlayerDto playerDto) =>
            new Player(playerDto);
    }
}