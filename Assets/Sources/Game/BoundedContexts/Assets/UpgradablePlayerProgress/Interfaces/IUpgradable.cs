﻿using System.Collections.Generic;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces
{
    public interface IUpgradable
    {
        int Money { get; set; }
        int AttackModifier { get; set; }
        int ArmorModifier { get; set; }
        float AttackDelay { get; set; }
        int HealthModifier { get; set; }
        Dictionary<string, int> UpgradeLevelStats { get; set; }
    }
}