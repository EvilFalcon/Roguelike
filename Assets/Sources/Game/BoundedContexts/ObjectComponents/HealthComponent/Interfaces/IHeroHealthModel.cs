namespace Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Interfaces
{
    public interface IHeroHealthModel : IHealthModel
    {
        void Heal(int health);
    }
}