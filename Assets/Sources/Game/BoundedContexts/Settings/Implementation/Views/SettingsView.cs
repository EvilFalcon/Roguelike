using Sources.Game.BoundedContexts.Settings.Implementation.Controllers;
using Sources.Game.Common.Mvp.Interfaces;
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

        private SettingsPresenter _presenter;

        public void Show()
        {
            _backButton.onClick.AddListener(OnBackButtonClick);
            _musicVolume.onValueChanged.AddListener(OnMusicVolumeChanged);
            _soundEffectsVolume.onValueChanged.AddListener(OnSoundEffectsVolumeChanged);
            _setEngLocalizationButton.onClick.AddListener(OnEngLocalizationButtonClick);
            _setRusLocalizationButton.onClick.AddListener(OnRusLocalizationButtonClick);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _backButton.onClick.RemoveListener(OnBackButtonClick);
            _musicVolume.onValueChanged.RemoveListener(OnMusicVolumeChanged);
            _soundEffectsVolume.onValueChanged.RemoveListener(OnSoundEffectsVolumeChanged);
            _setEngLocalizationButton.onClick.RemoveListener(OnEngLocalizationButtonClick);
            _setRusLocalizationButton.onClick.RemoveListener(OnRusLocalizationButtonClick);
            gameObject.SetActive(false);
        }

        public void Construct(SettingsPresenter presenter) =>
            _presenter = presenter;

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