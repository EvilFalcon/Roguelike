using System.ComponentModel;

namespace Sources.Game.BoundedContexts.Players.Interfaces
{
    public interface IPlayer
    {
        public int Money { get; }

        public int AttackModifier { get; }

        public int ArmorModifier { get; }

        public float AttackDelay { get; }
        public int HealthModifier { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}