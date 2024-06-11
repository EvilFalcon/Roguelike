using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.BehaviourTreeNods
{
    [Category("Movement/Direct")]
    [Description(" NavMesh destination point")]
    public class NavMeshSetDestination : ActionTask
    {
        [RequiredField] public BBParameter<Transform> HeroTransform;
        [RequiredField] public BBParameter<NavMeshAgent> Agent;

        private float Distance => Vector3.Distance(Agent.value.destination, Agent.value.transform.position);

        protected override void OnUpdate()
        {
            Agent.value.destination = HeroTransform.value.position;

            if (Distance - Agent.value.stoppingDistance < 0.1f)
                EndAction(true);
        }
    }
}