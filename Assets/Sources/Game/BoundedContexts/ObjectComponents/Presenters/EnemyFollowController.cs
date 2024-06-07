using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.BoundedContexts.ObjectComponents.FollowComponent;

namespace Sources.Game.BoundedContexts.ObjectComponents.Presenters
{
    public class EnemyFollowController
    {
        private readonly EnemyFollowComponent _followComponent;
        private readonly IHeroTransform _target;

        public EnemyFollowController(EnemyFollowComponent followComponent, IHeroTransform target)
        {
            _followComponent = followComponent;
            _target = target;
        }

        public void Enable()
        {
            _followComponent.Enable();
            _target.TransformChanged += OnPositionTargetChanged;
            SetDestination();
        }

        public void Disable()
        {
            _target.TransformChanged -= OnPositionTargetChanged;
            _followComponent.Disable();
        }

        private void OnPositionTargetChanged() =>
            SetDestination();

        public void SetSpeed()
        {
            _followComponent.NavMeshAgent.speed = 3;
        }

        private void SetDestination()
        {
            _followComponent.NavMeshAgent.SetDestination(_target.Transform.position);
            _followComponent.NavMeshAgent.destination = _target.Transform.position;
        }
    }
}