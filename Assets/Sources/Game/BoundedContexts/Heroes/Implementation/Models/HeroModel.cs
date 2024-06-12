using Sources.Game.BoundedContexts.Heroes.Interfaces.Model;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Model;
using Sources.Game.BoundedContexts.Players.Interfaces;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Models
{
    public class HeroModel : IHero
    {
        public HeroModel(IPlayer player)
        {
            AttackDelay = player.AttackDelay;
            Damage = player.AttackModifier;
            Armor = player.ArmorModifier;
            Health = new HealthModel(player.Health);
            Speed = player.Speed;
        }

        public float Speed { get; }

        public HealthModel Health { get; }

        public int Armor { get; }

        public int Damage { get; }

        public float AttackDelay { get; }
    }
}