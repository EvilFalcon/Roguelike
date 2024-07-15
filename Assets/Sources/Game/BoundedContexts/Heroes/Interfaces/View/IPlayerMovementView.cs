using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Interfaces.View
{
    public interface IPlayerMovementView: IHeroTransform
    {
        void Move(Vector3 direction);
        void Show();
        void Hide();
    }
}