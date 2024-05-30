using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Players.Interfaces;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Models
{
    public class HeroModelFactory
    {
        public HeroModel Create(IPlayer player) => 
            new(player);
    }
}