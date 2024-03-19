using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Interfaces.Services
{
    public interface ISceneConstructor
    {
        void ConstructScene(ISceneContext sceneContext);
    }
}