using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Heroes.Interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerViewFactories
{
    public class HeroViewFactory
    {
        private readonly HeroAssetProvider _heroAssetProvider;

        public HeroViewFactory(HeroAssetProvider heroAssetProvider)
        {
            _heroAssetProvider = heroAssetProvider;
        }

        public GameObject Create(IHero hero)
        {
            throw new NotImplementedException();
        }
    }
}