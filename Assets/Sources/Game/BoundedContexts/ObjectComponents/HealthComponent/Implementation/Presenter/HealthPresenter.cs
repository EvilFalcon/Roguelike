﻿using System;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Interfaces.Presenters;
using Sources.Game.BoundedContexts.SpawnerObjects.Implementation.EnemyPools;
using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using Sources.Game.Common.Models;
using UnityEngine;

namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Presenter
{
    public abstract class HealthPresenter : IHealthPresenter
    {
        protected readonly View.HealthComponent Component;
        private readonly IModel _model;

        public HealthPresenter(View.HealthComponent component, IModel model)
        {
            Component = component ?? throw new ArgumentNullException(nameof(component));
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        protected abstract void OnListenDie();

        public void Enable()
        {
            _model.HealthModel.Die += OnListenDie;
            Component.Enable();
        }

        public void Disable()
        {
            Component.Disable();
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

            Debug.Log($"{Component.name} мне больно вылечили");
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
        public HeroHealthPresenter(View.HealthComponent component, IModel model) : base(component, model)
        {
        }

        protected override void OnListenDie()
        {
        }
    }

    public class EnemyHealthPresenter : HealthPresenter
    {
        private readonly EnemyPool _pool;
        private readonly IEnemy _enemy;

        public EnemyHealthPresenter(View.HealthComponent component, IModel model, EnemyPool pool, IEnemy enemy) : base(component,
            model)
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