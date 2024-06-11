using System;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.View;
using Sources.Game.IDontCno;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Controllers
{
    public class HeroPresenter : IPresenter
    {
        private readonly HeroView _view;
        private readonly HeroModel _heroModel;

        public HeroPresenter(HeroView view, HeroModel heroModel)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _heroModel = heroModel ?? throw new ArgumentNullException(nameof(heroModel));
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }
    }
}