using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Assets.Interfaces.Scenes.Services
{
    public interface ISceneConstructor
    {
        void ConstructScene(ISceneContext sceneContext);
    }
}