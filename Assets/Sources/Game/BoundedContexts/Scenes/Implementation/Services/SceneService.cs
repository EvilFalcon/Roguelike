using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.Common.StateMachines.Decorators;
using Sources.Game.Common.StateMachines.Implementation;
using Sources.Game.Common.StateMachines.Interfaces;
using UniCtor.Contexts;
using UnityEngine.SceneManagement;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Services
{
    public class SceneService : ISceneConstructor, ISceneSwitcher,ISceneService
    {
        private readonly ISceneFactoryProvider _sceneFactoryProvider;

        private readonly IStateMachine<IScene> _stateMachine;
        private readonly UpdatableStateMachine<IScene> _updateHandler;
        private readonly FixedUpdatableStateMachine<IScene> _fixedUpdateHandler;
        private readonly LateUpdatableStateMachine<IScene> _lateUpdateHandler;

        public SceneService
        (
            ISceneFactoryProvider sceneFactoryProvider
        )
        {
            _sceneFactoryProvider = sceneFactoryProvider ?? throw new ArgumentNullException(nameof(sceneFactoryProvider));
            _stateMachine = new StateMachine<IScene>();
            _updateHandler = new UpdatableStateMachine<IScene>(_stateMachine);
            _fixedUpdateHandler = new FixedUpdatableStateMachine<IScene>(_stateMachine);
            _lateUpdateHandler = new LateUpdatableStateMachine<IScene>(_stateMachine);
        }
        
        public void Update(float deltaTime)
        {
            _updateHandler.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime) =>
            _fixedUpdateHandler.FixedUpdate(deltaTime);

        public void LateUpdate(float deltaTime) =>
            _lateUpdateHandler.LateUpdate(deltaTime);

        public void Change(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ConstructScene(ISceneContext sceneContext)
        {
            ISceneFactory factory = _sceneFactoryProvider.GetFactory(SceneManager.GetActiveScene().name, sceneContext);
            IScene state = factory.Create(this, sceneContext);
            _stateMachine.Change(state);
        }
    }
}