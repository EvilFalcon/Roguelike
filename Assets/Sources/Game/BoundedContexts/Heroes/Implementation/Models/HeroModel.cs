using Sources.Game.BoundedContexts.Heroes.Interfaces;
using Sources.Game.BoundedContexts.Heroes.Interfaces.Model;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.Common.Models;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Models
{
    public class HeroModel : ObservableModel, IHero
    {
        public HeroModel(IPlayer player)
        {
            AttackDelay = player.AttackDelay;
            AttackModifier = player.AttackModifier;
            ArmorModifier = player.ArmorModifier;
            Health = player.Health;
            Speed = player.Speed;
        }

        public float Speed { get; }

        public int Health { get; }

        public int ArmorModifier { get; }

        public int AttackModifier { get; }

        public float AttackDelay { get; }
    }
}