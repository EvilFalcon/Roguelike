using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Dragon;
using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Werewolf;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using Sources.Game.BoundedContexts.Maps.Implementation.Factories.Controllers;
using Sources.Game.BoundedContexts.Maps.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Scenes.Implementation.Models;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;
using Sources.Game.Common.StateMachines.Interfaces.Services;
using Sources.Game.DataTransferObjects.Implementation.Services;
using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IAssetService _assetService;
        private readonly IUpdateHandler _updateHandler;
        private readonly IUpdateService _updateService;
        private readonly IFixedUpdateHandler _fixedUpdateHandler;
        private readonly IFixedUpdateService _fixedUpdateService;
        private readonly ILateUpdateHandler _lateUpdateHandler;
        private readonly ILateUpdateService _lateUpdateService;
        private readonly GamePlayMapViewFactory _mapViewFactory;
        private readonly EnemyFactory _enemyFactory;
        private readonly SaveLoadedService _saveLoadedService;
        private readonly HeroViewFactory _heroViewFactory;
        private readonly HeroModelFactory _heroFactory;
        private readonly WerewolfFactory _werewolfFactory;
        private readonly DragonFactory _dragonFactory;

        public GameplaySceneFactory
        (
            IAssetService assetService,
            IInputService inputService,
            IUpdateHandler updateHandler,
            IUpdateService updateService,
            IFixedUpdateHandler fixedUpdateHandler,
            IFixedUpdateService fixedUpdateService,
            ILateUpdateHandler lateUpdateHandler,
            ILateUpdateService lateUpdateService,
            GamePlayMapViewFactory mapViewFactory,
            EnemyFactory enemyFactory,
            SaveLoadedService saveLoadedService,
            HeroViewFactory heroViewFactory,
            HeroModelFactory heroFactory,
            WerewolfFactory werewolfFactory,
            DragonFactory dragonFactory
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _fixedUpdateHandler = fixedUpdateHandler ?? throw new ArgumentNullException(nameof(fixedUpdateHandler));
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
            _lateUpdateHandler = lateUpdateHandler ?? throw new ArgumentNullException(nameof(lateUpdateHandler));
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
            _mapViewFactory = mapViewFactory ?? throw new ArgumentNullException(nameof(mapViewFactory));
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
            _saveLoadedService = saveLoadedService ?? throw new ArgumentNullException(nameof(saveLoadedService));
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
            _heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            _werewolfFactory = werewolfFactory ?? throw new ArgumentNullException(nameof(werewolfFactory));
            _dragonFactory = dragonFactory ?? throw new ArgumentNullException(nameof(dragonFactory));
        }

        public IScene Create(ISceneSwitcher sceneSwitcher, ISceneContext sceneContext) =>
            new GameplayScene(
                sceneSwitcher,
                _assetService,
                _updateHandler,
                _updateService,
                _fixedUpdateHandler,
                _fixedUpdateService,
                _lateUpdateHandler,
                _lateUpdateService,
                _mapViewFactory,
               
                _saveLoadedService,
                _enemyFactory,
                _heroViewFactory,
                _heroFactory,
                _werewolfFactory,
                _dragonFactory
            );
    }
}