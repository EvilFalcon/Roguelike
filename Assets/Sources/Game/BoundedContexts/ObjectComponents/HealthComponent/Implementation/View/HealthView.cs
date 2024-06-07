using Sources.Game.Common.Mvp.Interface;
using UnityEngine;

namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View
{
    public class HealthView : ComponentBase, IDamageable, IHeal
    {
        private IHealthPresenter _presenter;

        public void Conctruct(IHealthPresenter presenter)
        {
            _presenter = presenter;
        }

        public void TakeDamage(int damage)
        {
            _presenter.TakeDamage(damage);
        }
        

        public void Heal(int health)
        {
            _presenter.Heal(health);
        }
    }

    public interface IHeal
    {
        void Heal(int health);
    }

    public interface IHealthPresenter
    {
        void TakeDamage(int damage);
        void Heal(int health);
    }
}