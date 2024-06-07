using System.ComponentModel;
using Sources.Game.Common.Models;

namespace Sources.Game.BoundedContexts.Players.Interfaces
{
    public interface IPlayer
    {
        public int Money { get; }

        public int AttackModifier { get; }

        public int ArmorModifier { get; }

        public float AttackDelay { get; }
        public int Health { get; }
        float Speed { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}