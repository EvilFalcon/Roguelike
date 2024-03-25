using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Audio.Implementation.View;
using UniCtor.Contexts;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.Game.BoundedContexts.Audio.Implementation.Factories.View
{
    public class AudioViewFactory
    {
        private readonly AssetService<AssetProviderAudioView> _assetService;
        private readonly ISceneContext _sceneContext;

        public AudioViewFactory(AssetService<AssetProviderAudioView> assetService,ISceneContext sceneContext)
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
        }

        public AudioView Create()
        {
            var view = _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.AudioView);
            return view;
        }
    }
}