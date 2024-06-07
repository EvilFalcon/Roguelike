using Sources.Game.BoundedContexts.Heroes.Interfaces.View;

namespace Sources.Game.BoundedContexts.ObjectComponents.FollowComponent.Presenters
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
            SetSpeed();
            SetDestination();
        }

        public void Disable()
        {
            _target.TransformChanged -= OnPositionTargetChanged;
            _followComponent.Disable();
        }

        private void OnPositionTargetChanged() =>
            SetDestination();

        private void SetSpeed() =>
            _followComponent.NavMeshAgent.speed = 3;

        private void SetStoppingDistance() =>
            _followComponent.NavMeshAgent.stoppingDistance = 2.4f;

        private void SetDestination() =>
            _followComponent.NavMeshAgent.destination = _target.Transform.position;
    }
}