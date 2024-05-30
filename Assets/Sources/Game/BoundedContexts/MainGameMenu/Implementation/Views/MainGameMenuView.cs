using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
using Sources.Game.IDontCno;
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
        [SerializeField] private TextMeshProUGUI _upgradeStats;
       
        [SerializeField] private Button _buttonStartGame;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonUpgradeStats;

        private MainGameMenuPresenter _presenter;

        public void Show()
        {
            _buttonStartGame.onClick.AddListener(OnStartGameButtonClick);
            _buttonSettings.onClick.AddListener(OnSettingsButtonClick);
            _buttonUpgradeStats.onClick.AddListener(OnUpgradeStatsButtonClick);
            gameObject.SetActive(true);
            _presenter.Enable();
        }

        public void Hide()
        {
            _buttonStartGame.onClick.RemoveListener(OnStartGameButtonClick);
            _buttonSettings.onClick.RemoveListener(OnSettingsButtonClick);
            _buttonUpgradeStats.onClick.RemoveListener(OnUpgradeStatsButtonClick);
            gameObject.SetActive(false);
            _presenter.Disable();
        }

        public void SetMoney(int playerMoney) =>
            _playersMoney.text = playerMoney.ToString();

        public void SetButtonStartGameText(string text) =>
            _startGameButton.text = text;

        public void SetButtonSettingsText(string text) =>
            _settingsGameButton.text = text;

        public void Construct(MainGameMenuPresenter presenter) =>
            _presenter = presenter;

        private void OnSettingsButtonClick() =>
            _presenter.ShowSettings();

        private void OnUpgradeStatsButtonClick() =>
            _presenter.ShowUpgradeStats();

        private void OnStartGameButtonClick() =>
            _presenter.StartGame();
    }
}