using System;
using Sources.Game.BoundedContexts.Maps.Implementation.Models;
using Sources.Game.BoundedContexts.Maps.Implementation.View;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;

namespace Sources.Game.BoundedContexts.Maps.Implementation.Controllers
{
    public class GamePlayMapPresenter : IGamePlayScenePresenter
    {
        private readonly GamePlayMapView _view;

        private readonly IViewService _viewService;

        public GamePlayMapPresenter(GamePlayMapView view, IViewService viewService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
        }

        public void Enable() =>
            _view.Show();

        public void Disable() =>
            _view.Hide();

        private void SetLevelProgressBar(float value) =>
            _view.SetLevelProgressBar(value);

        private void SetLevelExpHeroProgressBar(float value) =>
            _view.SetLevelExpHeroProgressBar(value);

        private void SetCounterOfKilledEnemies(int value) =>
            _view.SetCounterOfKilledEnemies(value);

        public void OnPauseButtonClick() =>
            _viewService.HideForm(nameof(GamePlayMapView));
    }

    public interface IGamePlayScenePresenter
    {
        void OnPauseButtonClick();
        void Enable();
        void Disable();
    }
}