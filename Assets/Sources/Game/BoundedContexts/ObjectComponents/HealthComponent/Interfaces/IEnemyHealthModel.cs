namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Interfaces
{
    public interface IEnemyHealthModel : IHealthModel
    {
        void UpdateMaxHealth(int health);
    }
}