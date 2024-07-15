using System;
using System.Collections;
using Sources.Game.BoundedContexts.Maps.Implementation.Controllers;
using Sources.Game.BoundedContexts.Maps.Implementation.Models;
using Sources.Game.BoundedContexts.Maps.Implementation.View;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Maps.Implementation.Factories.Controllers
{
    public class GamePlayMapPresenterFactory : MonoBehaviour
    {
        private IViewService _viewService;

        public GamePlayMapPresenterFactory(IViewService viewService)
        {
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
        }

        public GamePlayMapPresenter Create
        (
            GamePlayMapView view
        )
        {
            return new GamePlayMapPresenter(view, _viewService);
        }
    }
}