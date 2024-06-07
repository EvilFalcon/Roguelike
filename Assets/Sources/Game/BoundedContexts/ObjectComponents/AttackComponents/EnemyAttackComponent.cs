using System;
using Sources.Game.Common.Mvp.Interface;
using UnityEngine;

namespace Sources.Game.BoundedContexts.ObjectComponents.AttackComponents
{
    [RequireComponent(typeof(SphereCollider))]
    public class EnemyAttackComponent : ComponentBase
    {
        private IEnemyAttackController _controller;

        public override void Enable() =>
            enabled = true;

        public override void Disable() =>
            enabled = false;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IDamageable damageableComponent) == false)
                return;

            Attack(damageableComponent);
        }

        public void Construct(IEnemyAttackController controller)
        {
            _controller = controller;
        }

        private void Attack(IDamageable other)
        {
            _controller.Attack(other);
        }
    }
}