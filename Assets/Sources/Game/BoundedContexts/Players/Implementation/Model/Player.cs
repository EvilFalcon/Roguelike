﻿using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.Common.Mvp.Implementation.Model;
using Sources.Game.DataTransferObjects.Implementation.DTO.Player;

namespace Sources.Game.BoundedContexts.Players.Implementation.Model
{
    public class Player : ObservableModel, IUpgradable, IPlayer
    {
        private int _money;
        private int _attackModifier;
        private int _armorModifier;
        private int _attackDelay;
        private int _helhsDelay;
        private  int _healthModifier;

        public Player(PlayerDto playerDto)
        {
            _money = playerDto.Money;
            _attackModifier = playerDto.AttackModifier;
            _armorModifier = playerDto.ArmorModifier;
            _attackDelay = playerDto.AttackDelay;
            _healthModifier = playerDto.Health;
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

        public int AttackDelay
        {
            get => _attackDelay;
            set => TrySetField(ref _attackDelay, value);
        }
        public int HealthModifier
        {
            get => _attackDelay;
            set => TrySetField(ref _healthModifier, value);
        }
    }
}