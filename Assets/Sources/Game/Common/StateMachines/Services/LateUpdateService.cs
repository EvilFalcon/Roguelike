using System;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;
using Sources.Game.Common.StateMachines.Interfaces.Services;

namespace Sources.Game.Common.StateMachines.Services
{
    public class LateUpdateService : ILateUpdateService, ILateUpdateHandler
    {
        public event Action<float> LateUpdated = delegate { };

        public void LateUpdate(float deltaTime) =>
            LateUpdated.Invoke(deltaTime);
    }
}