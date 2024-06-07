using System;
using Sources.Game.Common.Mvp.Interface;

namespace Sources.Game.BoundedContexts.ObjectComponents.AttackComponents
{
    public class EnemyAttackController
    {
        private readonly IAttackModel _attackModel;

        public EnemyAttackController(IAttackModel attackModel)
        {
            _attackModel = attackModel ?? throw new ArgumentNullException(nameof(attackModel));
        }

        public void Attack(IDamageable other)
        {
            if (_attackModel.AttackDelay >= 0)
                return;

            other.TakeDamage(_attackModel.Attack);
        }
    }
}