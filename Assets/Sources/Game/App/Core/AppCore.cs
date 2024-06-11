using System;
using JetBrains.Annotations;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using UniCtor.Attributes;
using UnityEngine;

namespace Sources.Game.App.Core
{
    public class AppCore : MonoBehaviour
    {
        private ISceneService _sceneService;

        private void Awake() =>
            DontDestroyOnLoad(this);

        private void Update() =>
            _sceneService?.Update(Time.deltaTime);

        private void FixedUpdate() =>
            _sceneService?.FixedUpdate(Time.fixedDeltaTime);

        private void LateUpdate() =>
            _sceneService?.LateUpdate(Time.deltaTime);

        [Constructor]
        [UsedImplicitly]
        private void Construct(ISceneService sceneService) =>
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
    }
}