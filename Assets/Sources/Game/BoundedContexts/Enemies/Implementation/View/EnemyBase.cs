using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using Sources.Game.BoundedContexts.ObjectComponents.AttackComponents;
using Sources.Game.BoundedContexts.ObjectComponents.FollowComponent;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.View
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyFollowComponent))]
    [RequireComponent(typeof(HealthComponent))]
    public abstract class EnemyBase : MonoBehaviour, IEnemy
    {
        public GameObject GameObject => gameObject;

        public void Enable() =>
            gameObject.SetActive(true);

        public void Disable() =>
            gameObject.SetActive(false);

        public void Construct(Vector3 initPosition) =>
            transform.position = initPosition;
    }
}