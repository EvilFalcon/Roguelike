using Sources.Game.Common.Mvp.Interface;

namespace Sources.Game.BoundedContexts.ObjectComponents.AttackComponents
{
    public interface IEnemyAttackController
    {
        void Attack(IDamageable other);
    }
}