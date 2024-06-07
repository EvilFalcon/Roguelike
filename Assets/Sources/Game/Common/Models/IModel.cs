using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Model;

namespace Sources.Game.Common.Models
{
    public interface IModel
    {
        public HealthModel HealthModel { get; }

        public int Armor { get; }
    }
}