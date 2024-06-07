using System;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Dragon;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.EnemyModels;
using Sources.Game.BoundedContexts.Enemies.Implementation.Models;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.BoundedContexts.ObjectComponents.AttackComponents;
using Sources.Game.BoundedContexts.ObjectComponents.FollowComponent;
using Sources.Game.BoundedContexts.ObjectComponents.FollowComponent.Presenters;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Presenter;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View;
using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.SpawnerObjects.Implementation.EnemyPools
{
    public class EnemyPool : SpawnObjectPool
    {
        private readonly IHeroTransform _transform;
        private readonly EnemyModelFactory _modelFactory;

        public EnemyPool(ISpawnObjectFactory factory, IHeroTransform transform, EnemyModelFactory modelFactory) : base(factory)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _modelFactory = modelFactory ?? throw new ArgumentNullException(nameof(modelFactory));
        }

        protected override IEnemy Build(IEnemy spawnObject, Vector3 spawnPosition)
        {
            EnemyModel model = _modelFactory.Create();
            spawnObject.Construct(spawnPosition);
            
            EnemyFollowComponent followComponent = spawnObject.GameObject.GetComponent<EnemyFollowComponent>();
            EnemyFollowController followController = new EnemyFollowController(followComponent, _transform);
            followController.Enable();
            
            HealthComponent healthComponent = spawnObject.GameObject.GetComponent<HealthComponent>();
            EnemyHealthPresenter healthPresenter = new EnemyHealthPresenter(healthComponent, model, this, spawnObject);
            healthComponent.Conctruct(healthPresenter);
            healthPresenter.Enable();
            
            EnemyAttackComponent attackComponent = spawnObject.GameObject.GetComponentInChildren<EnemyAttackComponent>();
            EnemyAttackController enemyAttackController = new EnemyAttackController(attackComponent, model);
            attackComponent.Construct(enemyAttackController);
            enemyAttackController.Enable();
            return spawnObject;
        }
    }
}