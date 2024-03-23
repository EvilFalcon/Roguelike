using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
using Sources.Game.Common.Mvp.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views
{
    public class MainGameMenuView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI _startGameButton;
        [SerializeField] private TextMeshProUGUI _settingsGameButton;
        [SerializeField] private TextMeshProUGUI _playersMoney;
        [SerializeField] private Button _buttonStartGame;
        [SerializeField] private Button _buttonSettings;

        private MainGameMenuPresenter _presenter;

        public void Show()
        {
            _buttonStartGame.onClick.AddListener(OnStartGameButtonClick);
            _buttonSettings.onClick.AddListener(OnSettingsButtonClick);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _buttonStartGame.onClick.RemoveListener(OnStartGameButtonClick);
            _buttonSettings.onClick.RemoveListener(OnSettingsButtonClick);
            gameObject.SetActive(false);
        }

        private void OnSettingsButtonClick()
        {
            _presenter.ShowSettings();
        }

        public void OnStartGameButtonClick()
        {
            _presenter.StartGame();
        }

        public void SetMoney(int playerMoney) =>
            _playersMoney.text = playerMoney.ToString();

        public void SetButtonStartGameText(string text) =>
            _startGameButton.text = text;

        public void SetButtonSettingsText(string text) =>
            _settingsGameButton.text = text;

        public void Construct(MainGameMenuPresenter presenter) =>
            _presenter = presenter;
    }
}