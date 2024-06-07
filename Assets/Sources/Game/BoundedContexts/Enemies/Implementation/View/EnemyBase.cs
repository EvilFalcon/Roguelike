using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.View
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class EnemyBase : MonoBehaviour, IEnemy
    {


        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Construct(Vector3 initPosition)
        {
            this.transform.position = initPosition;
        }

        public GameObject GameObject => gameObject;
    }
}