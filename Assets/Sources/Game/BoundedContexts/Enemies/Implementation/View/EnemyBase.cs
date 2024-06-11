using NodeCanvas.BehaviourTrees;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.View
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(HealthComponent))]
    public abstract class EnemyBase : MonoBehaviour, IEnemy
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private BehaviourTreeOwner _behaviourThee;

        public GameObject GameObject => gameObject;

        public void Enable()
        {
            gameObject.SetActive(true);
            _agent.enabled = true;
            _behaviourThee.enabled = true;
        }

        public void Disable()
        {
            _agent.enabled = false;
            _behaviourThee.enabled = false;
            gameObject.SetActive(false);
        }

        public void Construct(Vector3 initPosition) =>
            transform.position = initPosition;
    }
}