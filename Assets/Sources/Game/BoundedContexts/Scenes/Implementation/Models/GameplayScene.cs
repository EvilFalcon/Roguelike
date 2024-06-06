using System;
using System.Collections.Generic;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Enemies.Dragon;
using Sources.Game.BoundedContexts.Enemies.Factories.Werewolf;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.SpawnerObjects.EnemyPools;
using Sources.Game.BoundedContexts.SpawnerObjects.View;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;
using Sources.Game.Common.StateMachines.Interfaces.Services;

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
        private readonly HeroViewFactory _heroViewFactory;
        private readonly HeroModelFactory _heroFactory;
        private readonly IPlayer _player;
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
            HeroViewFactory heroViewFactory,
            HeroModelFactory heroFactory,
            IPlayer player,
            WerewolfFactory werewolfFactory,
            DragonFactory dragonFactory
        )
        {
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _updateHandler = updateHandler;
            _updateService = updateService;
            _fixedUpdateHandler = fixedUpdateHandler;
            _fixedUpdateService = fixedUpdateService;
            _lateUpdateHandler = lateUpdateHandler;
            _lateUpdateService = lateUpdateService;
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
            _heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _werewolfFactory = werewolfFactory ?? throw new ArgumentNullException(nameof(werewolfFactory));
            _dragonFactory = dragonFactory ?? throw new ArgumentNullException(nameof(dragonFactory));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();
            HeroModel player = _heroFactory.Create(_player);

            var heroView = _heroViewFactory.Create(player);
            SpawnerObject spawnerObjects = new SpawnerObject(heroView, new Dictionary<Type, SpawnObjectPool[]>()
            {
                {
                    typeof(EnemyPool), new SpawnObjectPool[]
                    {
                        new EnemyPool(_werewolfFactory,
                            heroView),
                        new EnemyPool(_dragonFactory, heroView)
                    }
                },
            });

            spawnerObjects.Spawn(typeof(EnemyPool), 25);
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
            _updateHandler.Update(deltaTime);
        }
    }
}