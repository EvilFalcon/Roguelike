using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using UniCtor.Builders;

namespace Sources.Game.BoundedContexts.Scenes.Interfaces.Factories
{
    public interface ISceneFactory
    {
        public IScene Create(IDependencyResolver dependencyResolver); //ToDO : ?
    }
}