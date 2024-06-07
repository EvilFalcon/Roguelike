using System;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Models
{
    public class HeroModelFactory
    {
        private readonly PlayerModelFactory _playerModelFactory;

        public HeroModelFactory(PlayerModelFactory playerModelFactory)
        {
            _playerModelFactory = playerModelFactory ?? throw new ArgumentNullException(nameof(playerModelFactory));
        }

        public HeroModel Create() => 
            new HeroModel(_playerModelFactory.Create());
    }
}