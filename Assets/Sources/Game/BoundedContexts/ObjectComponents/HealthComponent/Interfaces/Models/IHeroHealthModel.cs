namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Interfaces.Models
{
    public interface IHeroHealthModel : IHealthModel
    {
        void Heal(int health);
    }
}