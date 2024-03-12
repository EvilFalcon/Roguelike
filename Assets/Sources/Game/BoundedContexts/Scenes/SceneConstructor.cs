using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.Scenes.Services;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.Common.StateMachines.Interfaces.PureStateMachines;
using UniCtor.Builders;
using UniCtor.Contexts;
using UnityEngine.SceneManagement;

namespace Sources.Game.BoundedContexts.Scenes
{
    public class SceneConstructor : ISceneConstructor
    {
        private readonly ISceneFactoryProvider _sceneFactoryProvider;
        private readonly IPureStateMachine<IScene> _stateMachine;
        private readonly IDependencyResolver _dependencyResolver;

        public SceneConstructor(ISceneFactoryProvider sceneFactoryProvider, IPureStateMachine<IScene> pureStateMachine,
            IDependencyResolver dependencyResolver)
        {
            _sceneFactoryProvider = sceneFactoryProvider ?? throw new ArgumentNullException(nameof(sceneFactoryProvider));
            _stateMachine = pureStateMachine ?? throw new ArgumentNullException(nameof(pureStateMachine));
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
        }

        public void Change(string sceneName) =>
            SceneManager.LoadScene(sceneName);

        public void ConstructScene(ISceneContext sceneContext)
        {
            ISceneFactory factory = _sceneFactoryProvider.GetFactory(SceneManager.GetActiveScene().name, sceneContext);
            IScene state = factory.Create(_dependencyResolver); //ToDo : можно ли передавать (dependencyResolver)? 
            _stateMachine.Change(state);
        }
        
    }
}