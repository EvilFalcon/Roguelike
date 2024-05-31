using System.Collections.Generic;
using Sources.Game.Common.Models;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces
{
    public interface IUpgradable: IModel
    {
        int Money { get; set; }
        int AttackModifier { get; set; }
        int ArmorModifier { get; set; }
        float AttackDelay { get; set; }
        int Health { get; set; }
        Dictionary<string, int> UpgradeLevelStats { get; set; }
    }
}