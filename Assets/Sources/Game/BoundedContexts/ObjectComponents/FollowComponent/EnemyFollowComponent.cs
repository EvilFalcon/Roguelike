using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.BoundedContexts.ObjectComponents.Presenters;
using UnityEngine.AI;

namespace Sources.Game.BoundedContexts.ObjectComponents.FollowComponent
{
    public class EnemyFollowComponent : ComponentBase
    {
        public NavMeshAgent NavMeshAgent { get; private set; }

        public override void Enable()
        {
            if (NavMeshAgent == null)
                NavMeshAgent = GetComponent<NavMeshAgent>();

            NavMeshAgent.enabled = true;
            enabled = true;
        }

        public override void Disable()
        {
            enabled = false;
        }
    }
}