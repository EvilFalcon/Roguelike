using System;
using Sources.Game.Common.Mvp.Interface;

namespace Sources.Game.BoundedContexts.ObjectComponents.AttackComponents
{
    public class EnemyAttackController : IEnemyAttackController
    {
        private readonly EnemyAttackComponent _view;
        private readonly IAttackModel _attackModel;

        public EnemyAttackController(EnemyAttackComponent view, IAttackModel attackModel)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _attackModel = attackModel ?? throw new ArgumentNullException(nameof(attackModel));
        }

        public void Enable()
        {
            _view.Enable();
        }

        public void Disable()
        {
            _view.Disable();
        }

        public void Attack(IDamageable other)
        {
            if (_attackModel.AttackDelay >= 0)
                return;

            other.TakeDamage(_attackModel.Attack);
        }
    }
}