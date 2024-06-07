using System;
using Sources.Game.BoundedContexts.Enemies.Implementation.Models;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.Factories.EnemyModels
{
    public class EnemyModelFactory
    {
        private readonly EnemyFactory _enemyFactory;

        public EnemyModelFactory(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
        }
        
        public EnemyModel Create() =>
            new(_enemyFactory.Create());
    }
}