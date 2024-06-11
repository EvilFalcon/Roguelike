using System;

namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Interfaces.Models
{
    public interface IHealthModel
    {
        int Health { get; }

        event Action Die;

        void TakeDamage(int damage);
    }
}