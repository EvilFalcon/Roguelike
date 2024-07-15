using Sources.Game.BoundedContexts.Maps.Implementation.Controllers;
using Sources.Game.Common.Mvp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Game.BoundedContexts.Maps.Implementation.View
{
    public class GamePlayMapView : ViewBase
    {
        [SerializeField] private Slider _levelProgressBar;
        [SerializeField] private Slider _levelExpHeroProgressBar;
        [SerializeField] private TextMeshProUGUI _counterOfKilledEnemies;
        [SerializeField] private TextMeshProUGUI _counterGold;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Canvas _canvas2;

        private IGamePlayScenePresenter _presenter;

        protected override void Enable()
        {
            _canvas2.enabled = true;
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
            _presenter.Enable();
        }

        protected override void Disable()
        {
            _canvas2.enabled = false;
            _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
            _presenter.Disable();
        }

        public void Construct(IGamePlayScenePresenter presenter) =>
            _presenter = presenter;

        public void SetLevelProgressBar(float value) =>
            _levelProgressBar.value = value;

        public void SetLevelExpHeroProgressBar(float value) =>
            _levelExpHeroProgressBar.value = value;

        public void SetCounterOfKilledEnemies(int value) =>
            _counterOfKilledEnemies.text = value.ToString();

        private void OnPauseButtonClick() =>
            _presenter.OnPauseButtonClick();
    }
}