using Sources.Game.IDontCno;
using UnityEngine;

namespace Sources.Game.Common.Mvp
{
    public abstract class ViewBase : MonoBehaviour, IView
    {
        [SerializeField] private Canvas _canvas;

        protected abstract void Enable();
        protected abstract void Disable();

        public void Show()
        {
            Enable();
            _canvas.enabled = true;
        }

        public void Hide()
        {
            Disable();
            _canvas.enabled = false;
        }
    }
}