using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.Scenes.Services;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.Common.StateMachines.Implementation;
using UniCtor.Builders;
using UniCtor.Contexts;
using UnityEngine.SceneManagement;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Services
{
    public class SceneConstructor : ISceneConstructor, ISceneSwitcher
    {
        private readonly ISceneFactoryProvider _sceneFactoryProvider;

        private readonly StateMachine<IState> _stateMachine;

        public SceneConstructor(
            ISceneFactoryProvider sceneFactoryProvider,
            IDependencyResolver dependencyResolver)
        {
            _sceneFactoryProvider = sceneFactoryProvider ?? throw new ArgumentNullException(nameof(sceneFactoryProvider));
            _stateMachine = new StateMachine<IState>();
        }

        public void Change(string sceneName) =>
            SceneManager.LoadScene(sceneName);

        public void ConstructScene(ISceneContext sceneContext)
        {
            ISceneFactory factory = _sceneFactoryProvider.GetFactory(SceneManager.GetActiveScene().name, sceneContext);
            IScene state = factory.Create(this); //ToDo : можно ли передавать (dependencyResolver)? 
            _stateMachine.Change(state);
        }
    }
}