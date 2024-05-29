using System;
using Sources.Game.BoundedContexts.Audio.Implementation.View;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Audio.Implementation
{
    public class AudioController : IAudioController
    {
        private readonly AudioView _audioView;

        public AudioController(AudioView audioView) =>
            _audioView = audioView ?? throw new ArgumentNullException(nameof(audioView));

        public void EnableAudio() =>
            _audioView.Show();

        public void DisableAudio() =>
            _audioView.Hide();

        public void SetMusic(AudioClip clip) =>
            _audioView.SetMusic(clip);
        
        public void SetSound(AudioClip clip) =>
            _audioView.SetSound(clip);

        public void SetSoundVolume(float soundEffectsVolume) =>
            _audioView.SetSoundVolume(soundEffectsVolume);

        public void SetMusicVolume(float musicVolume) =>
            _audioView.SetMusicVolume(musicVolume);

        public void PlaySound() =>
            _audioView.PlaySound();

        public void PlayMusic() =>
            _audioView.PlayMusic();

        public void StopMusic() =>
            _audioView.StopMusic();

        public void StopSound() =>
            _audioView.StopSound();

        public void PauseMusic() =>
            _audioView.PauseMusic();

        public void PauseSound() =>
            _audioView.PauseSound();
    }
}