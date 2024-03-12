using Sources.Game.BoundedContexts.Assets.Interfaces.States;

namespace Sources.Game.Common.StateMachines.Interfaces.PureStateMachines
{
    public interface IPureStateMachine<in T> where T : class, IState
    {
        void Change(T state);
    }
}