using Sources.Game.BoundedContexts.Enemies.Interfaces;
using Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.Models
{
    public class Enemy : IEnemyUpgradable
    {
        public Enemy(EnemyData enemy)
        {
            Health = enemy.Health;
            Armor = enemy.Armor;
            Attack = enemy.Attack;
            AttackDelay = enemy.AttackDelay;
            Speed = enemy.Speed;
        }

        public int Health { get; set; }
        public int Armor { get; set; }
        public int Attack { get; set; }
        public float AttackDelay { get; set; }
        public float Speed { get; set; }
    }
}