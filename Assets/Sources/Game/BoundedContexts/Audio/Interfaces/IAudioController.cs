using UnityEngine;

namespace Sources.Game.BoundedContexts.Audio.Interfaces
{
    public interface IAudioController : ISoundController, IMusicController
    {
        void EnableAudio();
        void DisableAudio();
    }

    public interface ISoundController
    {
        void SetSound(AudioClip clip);
        void SetSoundVolume(float soundEffectsVolume);
        void PlaySound();
        void StopSound();
        void PauseSound();
    }

    public interface IMusicController
    {
        void SetMusic(AudioClip clip);
        void SetMusicVolume(float musicVolume);
        void PlayMusic();
        void StopMusic();
        void PauseMusic();
    }
}