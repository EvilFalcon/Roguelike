using System;
using System.Collections.Generic;
using Sources.Game.BoundedContexts.Enemies.Implementation.Models;
using Sources.Game.BoundedContexts.Enemies.Implementation.View;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Model;
using Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes;
using Sources.Game.DataTransferObjects.Implementation.Services;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.Factories
{
    public class EnemyFactory : IEnemyFactory, IEnemyUpgrader
    {
        private readonly Dictionary<string, EnemyData> _enemyData;
        private int _currentLevel = 1;

        public EnemyFactory(SaveLoadedService saveLoadedService)
        {
            if (saveLoadedService == null)
                throw new ArgumentNullException(nameof(saveLoadedService));

            _enemyData = saveLoadedService.Load<Dictionary<string, EnemyData>>(nameof(EnemyData));
        }

        public Enemy Create<T>() where T : EnemyBase
        {
            return new Enemy
            (
                CreateHealthMode<T>(),
                CreateArmor<T>(),
                CreateDamage<T>(),
                CreateSpeed<T>(),
                CreateAttackDelay<T>()
            );
        }

        public void SetLevel(int level)
        {
            _currentLevel = level;
        }

        private HealthModel CreateHealthMode<T>()
        {
            var strength = typeof(T).Name;
            int health = _enemyData[typeof(T).Name].Health;

            health += _enemyData[typeof(T).Name].HealthModifier * _currentLevel;
            return new HealthModel(health);
        }

        private int CreateArmor<T>()
        {
            int armor = _enemyData[typeof(T).Name].Armor;
            armor += _enemyData[typeof(T).Name].ArmorModifier * _currentLevel;
            return armor;
        }

        private int CreateDamage<T>()
        {
            int damage = _enemyData[typeof(T).Name].Damage;
            damage += _enemyData[typeof(T).Name].DamageModifier * _currentLevel;
            return damage;
        }

        private float CreateSpeed<T>()
        {
            return _enemyData[typeof(T).Name].Speed;
        }

        private float CreateAttackDelay<T>()
        {
            return _enemyData[typeof(T).Name].AttackDelay;
        }
    }

    public interface IEnemyUpgrader
    {
        void SetLevel(int level);
    }

    public interface IEnemyFactory
    {
        Enemy Create<T>() where T : EnemyBase;
    }
}