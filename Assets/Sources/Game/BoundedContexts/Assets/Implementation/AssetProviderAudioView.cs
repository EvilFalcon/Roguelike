using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Audio.Implementation.View;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class AssetProviderAudioView : AssetProviderBase
    {
        public AudioView AudioView { get; private set; }

        public override async Task LoadAsync() =>
            AudioView = await Load<AudioView>(nameof(AudioView));
    }
}