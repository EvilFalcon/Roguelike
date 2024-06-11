using System;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Interfaces.Models;
using Sources.Game.Common.Models;

namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Model
{
    public class HealthModel : ObservableModel, IHealthModel, IHeroHealthModel, IEnemyHealthModel
    {
        private readonly int _minValue = 0;
        private int _maxHealth;
        private int _currentHealth;

        public HealthModel(int healthPoint)
        {
            if (healthPoint < 0)
                throw new ArgumentOutOfRangeException(nameof(healthPoint));

            Health = healthPoint;
            _maxHealth = Health;
        }

        public int Health 
        {
            get => _currentHealth; 
            private set => TrySetField(ref _currentHealth, value);
        }

        public event Action Die;

        public void Heal(int health)
        {
            if (health <= 0)
                return;
            if (_maxHealth == Health)
                return;

            Health += health;
        }

        public void UpdateMaxHealth(int health)
        {
            if (health <= 0)
                return;

            _maxHealth += health;
            Health = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= _minValue)
                return;

            Health -= damage;

            if (Health >= 0)
                return;

            Die?.Invoke();
        }
    }
}