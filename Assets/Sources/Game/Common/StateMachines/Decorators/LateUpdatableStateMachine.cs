using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.Common.StateMachines.Interfaces;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;

namespace Sources.Game.Common.StateMachines.Decorators
{
    public class LateUpdatableStateMachine<T> : IStateMachine<T>, ILateUpdateHandler where T : class, IState
    {
        private readonly IStateMachine<T> _stateMachine;

        public LateUpdatableStateMachine(IStateMachine<T> stateMachine) =>
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

        public T CurrentState => _stateMachine.CurrentState;

        public void Change(T state) =>
            _stateMachine.Change(state);

        public void LateUpdate(float deltaTime) =>
            (CurrentState as ILateUpdateHandler)?.LateUpdate(deltaTime);
    }
}