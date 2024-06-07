namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Interfaces.Presenters
{
    public interface IHealthPresenter
    {
        void TakeDamage(int damage);
    }

    public interface IHeroHealthPresenter : IHealthPresenter
    {
        void Heal(int health);
    }

    public interface IEnemyHealthPresenter : IHealthPresenter
    {
        void Upgrade(int health);
    }
}