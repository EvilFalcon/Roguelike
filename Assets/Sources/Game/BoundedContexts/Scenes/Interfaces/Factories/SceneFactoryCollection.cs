using System;
using System.Collections.Generic;
using Sources.Game.BoundedContexts.Scenes.Implementation.Factories;
using Sources.Game.BoundedContexts.Scenes.Implementation.Modells;
using UniCtor.Builders;
using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Interfaces.Factories
{
    public class SceneFactoryCollection
    {
        private readonly Dictionary<string, Func<IDependencyResolver, ISceneFactory>> _sceneFactories;

        public SceneFactoryCollection()
        {
            _sceneFactories = new Dictionary<string, Func<IDependencyResolver, ISceneFactory>>()
            {
                [nameof(GameplayMenuScene)] = ResolveFactory<GameplayMenuSceneFactory>,
                [nameof(GameplayScene)] = ResolveFactory<GameplaySceneFactory>,
            };
        }

        public ISceneFactory GetFactory(string sceneName, ISceneContext sceneContext)
        {
            if (sceneContext == null)
                throw new ArgumentNullException(nameof(sceneContext));

            if (string.IsNullOrWhiteSpace(sceneName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(sceneName));

            if (_sceneFactories.ContainsKey(sceneName) == false)
                throw new InvalidOperationException(sceneName);

            return _sceneFactories[sceneName](sceneContext.DependencyResolver);
        }

        private ISceneFactory ResolveFactory<T>(IDependencyResolver resolver) where T : class, ISceneFactory =>
            resolver.Resolve<T>();
    }
}