using System;
using NodeCanvas.Framework;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Dragon;
using Sources.Game.BoundedContexts.Enemies.Implementation.Models;
using Sources.Game.BoundedContexts.Enemies.Implementation.View;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.BoundedContexts.ObjectComponents.AttackComponents;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Presenter;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View;
using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.SpawnerObjects.Implementation.EnemyPools
{
    public class EnemyPool<T> : SpawnObjectPool where T : EnemyBase
    {
        private readonly IHeroTransform _transform;
        private readonly IEnemyFactory _modelFactory;

        public EnemyPool(ISpawnObjectFactory factory, IHeroTransform transform, IEnemyFactory modelFactory) : base(factory)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _modelFactory = modelFactory ?? throw new ArgumentNullException(nameof(modelFactory));
        }

        protected override ISpawnObject Build(ISpawnObject spawnObject, Vector3 spawnPosition)
        {

            var t = typeof(T).Name;
            
            Enemy model = _modelFactory.Create<T>();
            
            spawnObject.Construct(spawnPosition);
            spawnObject
                .GameObject
                .GetComponentInChildren<Blackboard>()
                .SetVariableValue("_heroTransform", _transform.Transform);

            // EnemyFollowComponent followComponent = spawnObject.GameObject.GetComponent<EnemyFollowComponent>();
            // EnemyFollowController followController = new EnemyFollowController(followComponent, _transform);
            // followController.Enable();

            HealthComponent healthComponent = spawnObject.GameObject.GetComponent<HealthComponent>();
            EnemyHealthPresenter<T> healthPresenter = new EnemyHealthPresenter<T>(healthComponent, model, this, spawnObject);
            healthComponent.Conctruct(healthPresenter);
            healthPresenter.Enable();

            EnemyAttackComponent attackComponent = spawnObject.GameObject.GetComponentInChildren<EnemyAttackComponent>();
            EnemyAttackController enemyAttackController = new EnemyAttackController(attackComponent, model);
            attackComponent.Construct(enemyAttackController);
            enemyAttackController.Enable();

            spawnObject.Enable();

            return spawnObject;
        }
    }
}