using System;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.DataTransferObjects.Implementation.DTO.Player;
using Sources.Game.DataTransferObjects.Implementation.Services;

namespace Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories
{
    public class PlayerModelFactory
    {
        private readonly ISaveLoadedServices _saveLoadedServices;

        public PlayerModelFactory(ISaveLoadedServices saveLoadedServices)
        {
            _saveLoadedServices = saveLoadedServices ?? throw new ArgumentNullException(nameof(saveLoadedServices));
        }

        public Player Create() =>
            new(_saveLoadedServices.Load<PlayerData>(nameof(PlayerData)));
    }
}