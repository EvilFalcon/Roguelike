namespace Sources.Game.BoundedContexts.Enemies.Interfaces
{
    public interface IEnemyUpgradable
    {
        int Health { get; set; }
        int Armor { get; set; }
        int Attack { get; set; }
        float AttackDelay { get; set; }
        float Speed { get; set; }
    }
}