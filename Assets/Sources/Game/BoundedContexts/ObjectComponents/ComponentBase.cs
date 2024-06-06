using UnityEngine;

namespace Sources.Game.BoundedContexts.ObjectComponents
{
    public abstract class ComponentBase : MonoBehaviour
    {
        public virtual void Enable()
        {
            enabled = true;
        }

        public virtual void Disable()
        {
            enabled = false;
        }
    }
}