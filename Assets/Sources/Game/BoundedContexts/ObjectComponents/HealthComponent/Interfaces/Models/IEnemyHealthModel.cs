namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Interfaces.Models
{
    public interface IEnemyHealthModel : IHealthModel
    {
        void UpdateMaxHealth(int health);
    }
}