using System;
using Sources.Game.BoundedContexts.Enemies.View.Dragon;
using Sources.Game.BoundedContexts.ObjectComponents;
using Sources.Game.Common.Mvp;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Sources.Game.BoundedContexts.Enemies.View
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