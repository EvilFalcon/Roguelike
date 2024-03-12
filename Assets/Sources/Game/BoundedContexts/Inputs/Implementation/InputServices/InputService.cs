using Downloads.Plugins.SimpleInput.Scripts;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Inputs.Implementation.InputServices
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected Vector2 SimpleInputAxis()
        {
            return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        }
    }
}