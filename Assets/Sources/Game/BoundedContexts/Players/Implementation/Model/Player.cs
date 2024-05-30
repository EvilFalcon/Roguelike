using System.Collections.Generic;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.Common.Models;
using Sources.Game.DataTransferObjects.Implementation.DTO.Player;

namespace Sources.Game.BoundedContexts.Players.Implementation.Model
{
    public class Player : ObservableModel, IUpgradable, IPlayer
    {
        private int _money;
        private int _attackModifier;
        private int _armorModifier;
        private float _attackDelay;
        private int _health;
        private Dictionary<string, int> _upgradeLevelStats;

        public Player(PlayerData playerLiveData)
        {
            _money = playerLiveData.Money;
            _attackModifier = playerLiveData.AttackModifier;
            _armorModifier = playerLiveData.ArmorModifier;
            _attackDelay = playerLiveData.AttackDelay;
            _health = playerLiveData.Health;
            UpgradeLevelStats = playerLiveData.UpgradeStats;
        }

        public Dictionary<string, int> UpgradeLevelStats
        {
            get => _upgradeLevelStats;
            set => TrySetField(ref _upgradeLevelStats, value);
        }

        public int Money
        {
            get => _money;
            set => TrySetField(ref _money, value);
        }

        public int AttackModifier
        {
            get => _attackModifier;
            set => TrySetField(ref _attackModifier, value);
        }

        public int ArmorModifier
        {
            get => _armorModifier;
            set => TrySetField(ref _armorModifier, value);
        }

        public float AttackDelay
        {
            get => _attackDelay;
            set => TrySetField(ref _attackDelay, value);
        }

        public int Health
        {
            get => _health;
            set => TrySetField(ref _health, value);
        }

        public float Speed { get; }
    }
}