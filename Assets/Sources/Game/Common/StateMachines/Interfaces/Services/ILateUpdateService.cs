using System;

namespace Sources.Game.Common.StateMachines.Interfaces.Services
{
    public interface ILateUpdateService
    {
        event Action<float> LateUpdated;
    }
}