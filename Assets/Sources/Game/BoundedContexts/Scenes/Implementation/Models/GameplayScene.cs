using System;
using System.Collections.Generic;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Dragon;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Werewolf;
using Sources.Game.BoundedContexts.Enemies.Implementation.Models;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Boses;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Maps.Implementation.Factories.Views;
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
        private readonly GamePlayMapViewFactory _mapViewFactory;
        private readonly SaveLoadedService _saveLoadedService;
        private readonly EnemyFactory _enemyFactory;
        private readonly HeroViewFactory _heroViewFactory;
        private readonly HeroModelFactory _heroFactory;
        private readonly WerewolfFactory _werewolfFactory;
        private readonly DragonFactory _dragonFactory;
        private SpawnerObject _spawnerObjects;

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
            GamePlayMapViewFactory mapViewFactory,
            SaveLoadedService saveLoadedService,
            EnemyFactory enemyFactory,
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
            _mapViewFactory = mapViewFactory ?? throw new ArgumentNullException(nameof(mapViewFactory));
            _saveLoadedService = saveLoadedService ?? throw new ArgumentNullException(nameof(saveLoadedService));
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
            _heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            _werewolfFactory = werewolfFactory ?? throw new ArgumentNullException(nameof(werewolfFactory));
            _dragonFactory = dragonFactory ?? throw new ArgumentNullException(nameof(dragonFactory));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();

            Initialize();
            _spawnerObjects.Spawn(typeof(Enemy), 150);
            AddListeners();
        }

        private void Initialize()
        {
            HeroModel player = _heroFactory.Create();
            _mapViewFactory.Create();

            var hero = _heroViewFactory.Create(player, _lateUpdateService);

            _spawnerObjects = new SpawnerObject(hero.HeroTransform, new Dictionary<Type, SpawnObjectPool[]>
            {
                {
                    typeof(Enemy), new SpawnObjectPool[]
                    {
                        new EnemyPool<Werewolf>(_werewolfFactory,
                            hero.HeroTransform, _enemyFactory),
                        new EnemyPool<DragonFire>(_dragonFactory, hero.HeroTransform, _enemyFactory)
                    }
                },
            });
        }

        public void Exit()
        {
            _assetService.Release();
        }

        private void AddListeners()
        {
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