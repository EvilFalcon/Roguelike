using Sources.Game.DataTransferObjects.Implementation.DTO.Player;

namespace Sources.Game.BoundedContexts.Players.Implementation.LiveData
{
    public class PlayerLiveData
    {
        public PlayerLiveData(PlayerDta playerDta)
        {
            Money = playerDta.Money;
            AttackModifier = playerDta.AttackModifier;
            ArmorModifier = playerDta.ArmorModifier;
            AttackDelay = playerDta.AttackDelay;
            Health = playerDta.Health;
        }

        public int Money { get; }
        public int AttackModifier { get; }
        public int ArmorModifier { get; }
        public int AttackDelay { get; }
        public int Health { get; }
    }
}