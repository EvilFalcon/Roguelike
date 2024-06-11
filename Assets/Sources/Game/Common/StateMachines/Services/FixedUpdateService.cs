using System;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;
using Sources.Game.Common.StateMachines.Interfaces.Services;

namespace Sources.Game.Common.StateMachines.Services
{
    public class FixedUpdateService : IFixedUpdateService, IFixedUpdateHandler
    {
        public event Action<float> FixedUpdated = delegate { };

        public void FixedUpdate(float deltaTime) =>
            FixedUpdated.Invoke(deltaTime);
    }
}