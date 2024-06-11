using System;
using Sources.Game.BoundedContexts.Heroes.Implementation.Controllers;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.View;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Controllers
{
    public class HeroMovementControllerFactory
    {
        private readonly IInputService _inputService;

        public HeroMovementControllerFactory(IInputService inputService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public HeroMovementController Create(HeroMovementView view, HeroModel model)
        {
            return new HeroMovementController(view, model, _inputService);
        }
    }
}