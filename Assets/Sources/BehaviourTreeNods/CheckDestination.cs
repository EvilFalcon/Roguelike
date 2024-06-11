
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.BehaviourTreeNods
{
    [Category("✫ Blackboard")]
    public class CheckDestination : ConditionTask<NavMeshAgent>
    {
        protected override bool OnCheck()
        {
            float distance = Vector3.Distance(agent.destination, agent.transform.position);

            return distance - agent.stoppingDistance < 0.1f;
        }
    }
}