using UnityEngine;

namespace Sources.Game.Common.Mvp.Interfaces.IPlayerMovement
{
    public interface IPlayerMovementView
    {
        void Move(Vector3 direction);
        void Show();
        void Hide();
    }
}