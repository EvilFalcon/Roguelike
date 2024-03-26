using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Maperis.Interfaces;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Models
{
    public class InitScene : IScene
    {
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly IAudioController _audioController;
        private readonly ISettingsModelProvider _settingsModelProvider;

        public InitScene(ISceneSwitcher sceneSwitcher, IAudioController audioController, ISettingsModelProvider settingsModelProvider)
        {
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));

            _audioController = audioController ?? throw new ArgumentNullException(nameof(audioController));
            _settingsModelProvider = settingsModelProvider ?? throw new ArgumentNullException(nameof(settingsModelProvider));
        }

        public void Enter()
        {
            var settings = _settingsModelProvider.Model;
            _audioController.SetSoundVolume(settings.SoundEffectsVolume);
            _audioController.SetMusicVolume(settings.MusicVolume);
            _audioController.PlayMusic();
            _sceneSwitcher.Change(nameof(GameplayMenuScene));
        }

        public void Exit()
        {
        }
    }
}