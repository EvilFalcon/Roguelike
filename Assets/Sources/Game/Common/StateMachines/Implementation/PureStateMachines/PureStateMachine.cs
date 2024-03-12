using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.Common.StateMachines.Interfaces.PureStateMachines;

namespace Sources.Game.Common.StateMachines.Implementation.PureStateMachines
{
    public class PureStateMachine<T> : IPureStateMachine<T> where T : class, IState
    {
        protected T State { get; private set; }

        public void Change(T state)
        {
            State?.Exit();
            State = state;
            State?.Enter();
        }
    }
}