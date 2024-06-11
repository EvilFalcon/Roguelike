using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Model;
using Sources.Game.Common.Mvp.Interface;

namespace Sources.Game.Common.Models
{
    public interface IModel : IAttackModel
    {
        public HealthModel HealthModel { get; }

        public int Armor { get; }
    }
}