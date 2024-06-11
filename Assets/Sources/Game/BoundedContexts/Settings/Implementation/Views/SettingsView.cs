using Sources.Game.BoundedContexts.Settings.Implementation.Controllers;
using Sources.Game.IDontCno;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Views
{
    public class SettingsView : MonoBehaviour, IView
    {
        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Slider _soundEffectsVolume;

        [SerializeField] private Button _setRusLocalizationButton;
        [SerializeField] private Button _setEngLocalizationButton;
        [SerializeField] private Button _backButton;

        [SerializeField] private TextMeshProUGUI _musicVolumeText;
        [SerializeField] private TextMeshProUGUI _soundEffectsVolumeText;
        [SerializeField] private TextMeshProUGUI _backButtonText;

        private SettingsPresenter _presenter;

        public void Show()
        {
            _backButton.onClick.AddListener(OnBackButtonClick);
            _musicVolume.onValueChanged.AddListener(OnMusicVolumeChanged);
            _soundEffectsVolume.onValueChanged.AddListener(OnSoundEffectsVolumeChanged);
            _setEngLocalizationButton.onClick.AddListener(OnEngLocalizationButtonClick);
            _setRusLocalizationButton.onClick.AddListener(OnRusLocalizationButtonClick);
            _presenter?.Enable();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _backButton.onClick.RemoveListener(OnBackButtonClick);
            _musicVolume.onValueChanged.RemoveListener(OnMusicVolumeChanged);
            _soundEffectsVolume.onValueChanged.RemoveListener(OnSoundEffectsVolumeChanged);
            _setEngLocalizationButton.onClick.RemoveListener(OnEngLocalizationButtonClick);
            _setRusLocalizationButton.onClick.RemoveListener(OnRusLocalizationButtonClick);
            _presenter.Disable();
            gameObject.SetActive(false);
        }

        public void SetLocalizationMode(string musicVolumeText, string soundEffectsVolumeText, string backButtonText)
        {
            _musicVolumeText.text = musicVolumeText;
            _soundEffectsVolumeText.text = soundEffectsVolumeText;
            _backButtonText.text = backButtonText;
        }

        public void Construct(SettingsPresenter presenter) =>
            _presenter = presenter;
        
        public void SetMusicVolume(float volume) =>
            _musicVolume.value = volume;

        public void SetSoundVolume(float volume) =>
            _soundEffectsVolume.value = volume;

        private void OnBackButtonClick() =>
            _presenter.OnBackButtonClick();

        private void OnMusicVolumeChanged(float value) =>
            _presenter.SetMusicVolume(_musicVolume.value);

        private void OnSoundEffectsVolumeChanged(float value) =>
            _presenter.SetSoundEffectsVolume(_soundEffectsVolume.value);

        private void OnRusLocalizationButtonClick() =>
            _presenter.SetRusLocalization();

        private void OnEngLocalizationButtonClick() =>
            _presenter.SetEngLocalization();
    }
}