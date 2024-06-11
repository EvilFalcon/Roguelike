using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Presenter;
using Sources.Game.Common.Mvp.Interface;

namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View
{
    public class HealthComponent : ComponentBase, IDamageable, IHeal
    {
        private HealthPresenter _presenter;

        public void Conctruct(HealthPresenter presenter)
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
}