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
            Attack = player.AttackModifier;
            Armor = player.ArmorModifier;
            HealthModel = new HealthModel(player.Health);
            Speed = player.Speed;
        }

        public float Speed { get; }

        public HealthModel HealthModel { get; }

        public int Armor { get; }

        public int Attack { get; }

        public float AttackDelay { get; }
    }
}