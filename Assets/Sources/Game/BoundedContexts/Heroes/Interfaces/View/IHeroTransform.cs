﻿using System;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Interfaces.View
{
    public interface IHeroTransform
    {
        Transform Transform { get; }
       
        event Action TransformChanged;
    }
}