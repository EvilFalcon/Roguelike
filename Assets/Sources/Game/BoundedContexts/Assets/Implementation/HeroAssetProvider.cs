using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Heroes.Implementation.View.HeroMovementView;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class HeroAssetProvider : AssetProviderBase
    {
        public HeroMovementView Player { get; private set; }

        public override async Task LoadAsync()
        {
            Player = await Load<HeroMovementView>(nameof(Player));
        }
    }
}