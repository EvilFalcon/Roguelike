using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Interfaces.View
{
    public interface IPlayerMovementView
    {
        void Move(Vector3 direction);
        void Show();
        void Hide();
    }
}