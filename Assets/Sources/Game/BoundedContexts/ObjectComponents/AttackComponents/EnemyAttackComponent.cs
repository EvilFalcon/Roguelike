using System;
using Sources.Game.Common.Mvp.Interface;
using UnityEngine;

namespace Sources.Game.BoundedContexts.ObjectComponents.AttackComponents
{
    [RequireComponent(typeof(SphereCollider))]
    public class EnemyAttackComponent : ComponentBase
    {
        private EnemyAttackController _controller;

        public override void Enable() =>
            enabled = true;

        public override void Disable() =>
            enabled = false;

        private void OnCollisionEnter(IDamageable other)
        {
            Attack(other);
        }

        public void Construct(EnemyAttackController controller)
        {
            _controller = controller;
        }
        
        private void Attack(IDamageable other)
        {
            _controller.Attack(other);
        }
        
        
    }
}