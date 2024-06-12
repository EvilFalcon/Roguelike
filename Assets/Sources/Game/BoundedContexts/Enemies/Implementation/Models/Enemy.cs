using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Model;
using Sources.Game.Common.Models;
using Sources.Game.Common.Mvp.Interface;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.Models
{
    public class Enemy: IAttackModel,IModel
    {
        public Enemy(HealthModel health, int armor, int damage, float attackDelay, float speed)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
            AttackDelay = attackDelay;
            Speed = speed;
        }

        public HealthModel Health { get; }
        public int Armor { get; }
        public int Damage { get; }
        public float AttackDelay { get; }
        public float Speed { get; }
    }
}