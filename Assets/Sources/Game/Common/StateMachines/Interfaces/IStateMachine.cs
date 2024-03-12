using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.Common.StateMachines.Interfaces.PureStateMachines;

namespace Sources.Game.Common.StateMachines.Interfaces
{
    public interface IStateMachine<T> : IPureStateMachine<T> where T : class, IState
    {
        public T CurrentState { get; }
    }
}