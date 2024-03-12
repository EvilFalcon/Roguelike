using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Scenes.Implementation.Modells;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using UniCtor.Builders;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplaySceneFactory : ISceneFactory
    {
        public IScene Create(IDependencyResolver dependencyResolver) =>
            dependencyResolver.Resolve<GameplayScene>();
    }
}