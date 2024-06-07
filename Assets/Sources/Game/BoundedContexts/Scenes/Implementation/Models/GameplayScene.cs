using System;
using System.Collections.Generic;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Dragon;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.EnemyModels;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Werewolf;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.SpawnerObjects.Implementation;
using Sources.Game.BoundedContexts.SpawnerObjects.Implementation.EnemyPools;
using Sources.Game.BoundedContexts.SpawnerObjects.Implementation.View;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;
using Sources.Game.Common.StateMachines.Interfaces.Services;
using Sources.Game.DataTransferObjects.Implementation.Services;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Models
{
    public class GameplayScene : IScene, IUpdateHandler, IFixedUpdateHandler, ILateUpdateHandler
    {
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly IAssetService _assetService;
        private readonly IUpdateHandler _updateHandler;
        private readonly IUpdateService _updateService;
        private readonly IFixedUpdateHandler _fixedUpdateHandler;
        private readonly IFixedUpdateService _fixedUpdateService;
        private readonly ILateUpdateHandler _lateUpdateHandler;
        private readonly ILateUpdateService _lateUpdateService;
        private readonly EnemyFactory _enemyFactory;
        private readonly EnemyModelFactory _enemyModelFactory;
        private readonly SaveLoadedService _saveLoadedService;
        private readonly HeroViewFactory _heroViewFactory;
        private readonly HeroModelFactory _heroFactory;
        private readonly WerewolfFactory _werewolfFactory;
        private readonly DragonFactory _dragonFactory;

        public GameplayScene
        (
            ISceneSwitcher sceneSwitcher,
            IAssetService assetService,
            IUpdateHandler updateHandler,
            IUpdateService updateService,
            IFixedUpdateHandler fixedUpdateHandler,
            IFixedUpdateService fixedUpdateService,
            ILateUpdateHandler lateUpdateHandler,
            ILateUpdateService lateUpdateService,
            EnemyFactory enemyFactory,
            EnemyModelFactory enemyModelFactory,
            SaveLoadedService saveLoadedService,
            HeroViewFactory heroViewFactory,
            HeroModelFactory heroFactory,
            WerewolfFactory werewolfFactory,
            DragonFactory dragonFactory
        )
        {
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _fixedUpdateHandler = fixedUpdateHandler ?? throw new ArgumentNullException(nameof(fixedUpdateHandler));
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
            _lateUpdateHandler = lateUpdateHandler ?? throw new ArgumentNullException(nameof(lateUpdateHandler));
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
            _enemyModelFactory = enemyModelFactory ?? throw new ArgumentNullException(nameof(enemyModelFactory));
            _saveLoadedService = saveLoadedService ?? throw new ArgumentNullException(nameof(saveLoadedService));
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
            _heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            _werewolfFactory = werewolfFactory ?? throw new ArgumentNullException(nameof(werewolfFactory));
            _dragonFactory = dragonFactory ?? throw new ArgumentNullException(nameof(dragonFactory));
        }

        public async void Enter()
        {
            //_saveLoadedService.SystemCreateJson();
            await _assetService.LoadAsync();
            HeroModel player = _heroFactory.Create();

            var hero = _heroViewFactory.Create(player);
            SpawnerObject spawnerObjects = new SpawnerObject(hero.HeroTransform, new Dictionary<Type, SpawnObjectPool[]>
            {
                {
                    typeof(EnemyPool), new SpawnObjectPool[]
                    {
                        new EnemyPool(_werewolfFactory,
                            hero.HeroTransform, _enemyModelFactory),
                      //  new EnemyPool(_dragonFactory, hero.HeroTransform, _enemyModelFactory)
                    }
                },
            });

            spawnerObjects.Spawn(typeof(EnemyPool), 1);
            Initialize();
            AddListeners();
        }

        private void Initialize()
        {
        }

        public void Exit()
        {
            _assetService.Release();
        }

        private void AddListeners()
        {
            _updateService.Updated += Update;
            _fixedUpdateService.FixedUpdated += FixedUpdate;
            _lateUpdateService.LateUpdated += LateUpdate;
        }

        public void Update(float deltaTime)
        {
            _updateHandler.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            _fixedUpdateHandler.FixedUpdate(deltaTime);
        }

        public void LateUpdate(float deltaTime)
        {
            _lateUpdateHandler.LateUpdate(deltaTime);
        }
    }
}