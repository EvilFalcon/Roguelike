using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.View
{
    public class Hero : MonoBehaviour
    {
        public IHeroTransform HeroTransform { get; private set; }

        public void Construct(IHeroTransform heroTransform)
        {
            HeroTransform = heroTransform;
        }
    }
}