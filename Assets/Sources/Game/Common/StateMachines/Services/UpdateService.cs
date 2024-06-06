using System;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;
using Sources.Game.Common.StateMachines.Interfaces.Services;

namespace Sources.Game.Common.StateMachines.Services
{
    public class UpdateService : IUpdateService, IUpdateHandler
    {
        public event Action<float> Updated = delegate { };

        public void Update(float deltaTime) =>
            Updated.Invoke(deltaTime);
    }
}