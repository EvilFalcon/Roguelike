using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Interfaces.Factories
{
    public interface ISceneFactory
    {
        public IScene Create(ISceneSwitcher sceneSwitcher, ISceneContext sceneContext); //ToDO : ?
    }
}