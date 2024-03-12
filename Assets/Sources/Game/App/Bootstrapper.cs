﻿using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.Scenes.Services;
using UniCtor.Attributes;
using UniCtor.Contexts;
using UnityEngine;

namespace Sources.Game.App
{
    [DefaultExecutionOrder(-1)]
    public class Bootstrapper : MonoBehaviour
    {
        [Constructor]
        private void Construct(ISceneContext sceneContext, ISceneConstructor sceneConstructor)
        {
            ISceneContext context = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));

            if (sceneConstructor == null)
                throw new ArgumentNullException(nameof(sceneConstructor));

            sceneConstructor.ConstructScene(context);
        }
    }
}