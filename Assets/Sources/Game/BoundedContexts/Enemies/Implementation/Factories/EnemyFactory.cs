using Sources.Game.BoundedContexts.Enemies.Implementation.Models;
using Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes;
using Sources.Game.DataTransferObjects.Implementation.Services;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.Factories
{
    public class EnemyFactory
    {
        private readonly SaveLoadedService _saveLoadedService;

        public EnemyFactory(SaveLoadedService saveLoadedService)
        {
            _saveLoadedService = saveLoadedService;
        }
        
        public Enemy Create() =>
            new(_saveLoadedService.Load<EnemyData>(nameof(EnemyData)));
    }
}