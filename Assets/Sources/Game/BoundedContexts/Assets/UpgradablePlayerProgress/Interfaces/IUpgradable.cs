namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces
{
    public interface IUpgradable
    {
        int Money { get; set; }
        int AttackModifier { get; set; }
        int ArmorModifier { get; set; }
        int AttackDelay { get; set; }
        int HealthModifier { get; set; }
    }
}