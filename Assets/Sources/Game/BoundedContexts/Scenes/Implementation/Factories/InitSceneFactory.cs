using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Maperis.Interfaces;
using Sources.Game.BoundedContexts.Scenes.Implementation.Models;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class InitSceneFactory : ISceneFactory
    {
        private readonly IAudioController _audioController;
        private readonly ISettingsModelProvider _settingsModelProvider;

        public InitSceneFactory
        (
            IAudioController audioController,
            ISettingsModelProvider settingsModelProvider
        )
        {
            _audioController = audioController ?? throw new ArgumentNullException(nameof(audioController));
            _settingsModelProvider = settingsModelProvider;
        }

        public IScene Create(ISceneSwitcher sceneSwitcher, ISceneContext sceneContext) =>
            new InitScene(sceneSwitcher, _audioController, _settingsModelProvider);
    }
}