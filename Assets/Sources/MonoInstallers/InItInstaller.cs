using Sources.Game.BoundedContexts.Assets.Interfaces.Scenes.Services;
using Sources.Game.BoundedContexts.Scenes;
using Sources.Game.BoundedContexts.Scenes.Implementation.Services;
using UniCtor.Installers;
using UniCtor.Services;

namespace Sources.MonoInstallers
{
    public class InItInstaller : MonoInstaller
    {
        public override void OnConfigure(IServiceCollection services)
        {
            services.RegisterAsSingleton<ISceneConstructor, SceneConstructor>()
                ;
        }
    }
}