using System;

namespace Sources.Game.Common.StateMachines.Interfaces.Services
{
    public interface IFixedUpdateService
    {
        event Action<float> FixedUpdated;
    }
}