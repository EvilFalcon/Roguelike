using UnityEngine;

namespace Sources.Game.BoundedContexts.Audio.Implementation.View
{
    public class AudioView : MonoBehaviour
    {
        [SerializeField] private AudioSource _sound;
        [SerializeField] private AudioSource _music;

        private static int a;
        
        private void Awake() =>
            DontDestroyOnLoad(this);

        public void PlayMusic() =>
            _music.Play();

        public void PlaySound() =>
            _sound.Play();

        public void PauseMusic() =>
            _music.Pause();

        public void PauseSound() =>
            _sound.Pause();

        public void StopMusic() =>
            _music.Stop();

        public void StopSound() =>
            _sound.Stop();

        public void SetSoundVolume(float volume) =>
            _sound.volume = volume;

        public void SetMusicVolume(float volume) =>
            _music.volume = volume;

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        public void SetSound(AudioClip clip) =>
            _sound.PlayOneShot(clip);

        public void SetMusic(AudioClip clip) =>
            _music.PlayOneShot(clip);
    }
}