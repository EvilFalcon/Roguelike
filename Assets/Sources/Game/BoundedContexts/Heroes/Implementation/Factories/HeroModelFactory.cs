using Sources.Game.BoundedContexts.Heroes.Implementation.Modells;
using Sources.Game.BoundedContexts.Players.Interfaces;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Factories
{
    public class HeroModelFactory
    {
        public HeroModel Create(IPlayer player) => 
            new(player);
    }
}