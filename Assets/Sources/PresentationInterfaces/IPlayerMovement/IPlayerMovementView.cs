using UnityEngine;

namespace PresentationInterfaces.IPlayerMovement
{
    public interface IPlayerMovementView
    {
        void Move(Vector3 direction);
        void Show();
        void Hide();
    }
}