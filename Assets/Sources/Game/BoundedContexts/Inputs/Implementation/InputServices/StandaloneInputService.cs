using UnityEngine;

namespace Sources.Game.BoundedContexts.Inputs.Implementation.InputServices
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {       
                Vector2 axis = SimpleInputAxis();

                if (axis == Vector2.zero)
                {
                    axis = UnityAxis();
                }

                return axis;
            }
        }

        private Vector2 UnityAxis()
        {
            return new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
        }
    }
}