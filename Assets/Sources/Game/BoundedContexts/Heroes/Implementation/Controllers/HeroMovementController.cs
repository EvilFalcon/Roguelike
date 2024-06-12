using System;
using Sources.Game.BoundedContexts.Heroes.Implementation.Animations;
using Sources.Game.BoundedContexts.Heroes.Implementation.Animations.Controllers;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Controllers
{
    public class HeroMovementController
    {
        private readonly HeroModel _model;
        private readonly IPlayerMovementView _view;
        private readonly IInputService _inputService;
        private readonly AnimationController _animationController;
        private readonly Camera _camera;

        public HeroMovementController
        (
            IPlayerMovementView view,
            HeroModel model,
            IInputService inputService
           // AnimationController animationController
        )
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
         //   _animationController = animationController ?? throw new ArgumentNullException(nameof(animationController));
            _camera = Camera.main;
        }

        public void OnEnabled() =>
            _view.Show();

        public void OnDisabled() =>
            _view.Hide();

        public void MovePlayer(Transform transform)
        {
            if (TryGetPlayerMovementVector(out Vector3 movementVector) == false)
            {
                return;
            }
            
            transform.forward = movementVector;

            movementVector += Physics.gravity;

            Vector3 deltaPosition = movementVector * (_model.Speed * Time.deltaTime);
            
            _view.Move(deltaPosition);
        }

        private bool TryGetPlayerMovementVector(out Vector3 movementVector)
        {
            movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude < 0.5f) //TODO : вынести в конфиг 0.5f 
                return false;

            movementVector = _camera.transform.TransformDirection(_inputService.Axis);
            movementVector.y = 0;
            movementVector.Normalize();

            return true;
        }
    }
}