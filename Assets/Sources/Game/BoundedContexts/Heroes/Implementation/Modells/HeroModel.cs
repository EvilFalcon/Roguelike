using Sources.Game.BoundedContexts.Heroes.Interfaces;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.Common.Mvp.Implementation.Model;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Modells
{
    public class HeroModel: ObservableModel, IHero
    {
        public HeroModel(IPlayer player)
        { 
            AttackDelay = player.AttackDelay;
           AttackModifier = player.AttackModifier;
           ArmorModifier = player.ArmorModifier;
           Health = player.HealthModifier;
        }

        public int Health { get; }

        public int ArmorModifier { get; }

        public int AttackModifier { get; }

        public int AttackDelay { get; }
    }
}