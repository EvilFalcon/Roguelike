using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Interfaces.Factories
{
    public interface ISceneFactoryProvider
    {
        ISceneFactory GetFactory(string sceneName, ISceneContext sceneContext);
    }
}