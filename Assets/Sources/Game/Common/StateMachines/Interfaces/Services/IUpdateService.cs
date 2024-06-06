using System;

namespace Sources.Game.Common.StateMachines.Interfaces.Services
{
    public interface IUpdateService
    {
        event Action<float> Updated;
    }
}