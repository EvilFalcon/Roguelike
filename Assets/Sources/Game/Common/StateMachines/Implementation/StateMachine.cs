using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.Common.StateMachines.Implementation.PureStateMachines;
using Sources.Game.Common.StateMachines.Interfaces;

namespace Sources.Game.Common.StateMachines.Implementation
{
    public sealed class StateMachine<T> : PureStateMachine<T>, IStateMachine<T> where T : class, IState
    {
        public T CurrentState => State;
    }
}