using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Model;
using Sources.Game.Common.Models;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.Models
{
    public class EnemyModel : IModel
    {
        
        public EnemyModel(Enemy enemy)
        {
            HealthModel = new HealthModel(enemy.Health);
            Armor = enemy.Armor;
            Attack = enemy.Attack;
            AttackDelay = enemy.AttackDelay;
            Speed = enemy.Speed;
        }

        public HealthModel HealthModel { get; }

        public int Armor { get; }

        public int Attack { get; }

        public float AttackDelay { get; }

        public float Speed { get; }
    }
}