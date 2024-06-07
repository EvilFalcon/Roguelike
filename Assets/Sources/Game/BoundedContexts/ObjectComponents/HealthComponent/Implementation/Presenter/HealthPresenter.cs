using System;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View;
using Sources.Game.BoundedContexts.SpawnerObjects.Implementation.EnemyPools;
using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using Sources.Game.Common.Models;

namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Presenter
{
    public abstract class HealthPresenter : IHealthPresenter
    {
        protected readonly HealthView View;
        private readonly IModel _model;

        public HealthPresenter(HealthView view, IModel model)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        protected abstract void OnListenDie();

        public void Enable()
        {
            _model.HealthModel.Die += OnListenDie;
            View.Enable();
        }

        public void Disable()
        {
            View.Disable();
            _model.HealthModel.Die -= OnListenDie;
        }

        public void Upgrade(int health)
        {
            _model.HealthModel.UpdateMaxHealth(health);
        }

        public void TakeDamage(int damage)
        {
            damage = damage - _model.Armor;
            if (damage <= 0)
                damage = 0;

            _model.HealthModel.TakeDamage(damage);
        }

        public void Heal(int health)
        {
            if (health <= 0)
                return;

            _model.HealthModel.Heal(health);
        }
    }

    public class HeroHealthPresenter : HealthPresenter
    {
        public HeroHealthPresenter(HealthView view, IModel model) : base(view, model)
        {
        }

        protected override void OnListenDie()
        {
            throw new NotImplementedException();
        }
    }

    public class EnemyHealthPresenter : HealthPresenter
    {
        private readonly EnemyPool _pool;
        private readonly IEnemy _enemy;

        public EnemyHealthPresenter(HealthView view, IModel model, EnemyPool pool, IEnemy enemy) : base(view, model)
        {
            _pool = pool ?? throw new ArgumentNullException(nameof(pool));
            _enemy = enemy;
        }

        protected override void OnListenDie()
        {
            _pool.ReturnToPool(_enemy);
        }
    }
}