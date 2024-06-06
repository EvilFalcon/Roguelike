using Sources.Game.Common.StateMachines.Interfaces;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;

namespace Sources.Game.BoundedContexts.Scenes.Interfaces.Services
{
    public interface ISceneService : IUpdateHandler, IFixedUpdateHandler, ILateUpdateHandler
    {
    }
}