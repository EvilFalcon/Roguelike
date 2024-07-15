using System;
using Sources.Game.BoundedContexts.Heroes.Implementation.Animations.Controllers;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using Sources.Game.Common.StateMachines.Interfaces.Services;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Controllers
{
    public class HeroMovementController
    {
        private readonly HeroModel _model;
        private readonly IPlayerMovementView _view;
        private readonly IInputService _inputService;
        private readonly ILateUpdateService _lateUpdateService;
        private readonly AnimationController _animationController;
        private readonly Camera _camera;

        public HeroMovementController
        (IPlayerMovementView view,
            HeroModel model,
            IInputService inputService, ILateUpdateService lateUpdateService
            // AnimationController animationController
        )
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
            //   _animationController = animationController ?? throw new ArgumentNullException(nameof(animationController));
            _camera = Camera.main;
        }

        public void Enabled()
        {
            _lateUpdateService.LateUpdated += Update;
            _view.Show();
        }

        public void Disabled()
        {
            _lateUpdateService.LateUpdated -= Update;
            _view.Hide();
        }

        private void Update(float deltaTime)
        {
            MovePlayer(_view.Transform);
        }

        public void MovePlayer(Transform transform)
        {
            if (TryGetPlayerMovementVector(out Vector3 movementVector) == false)
            {
                //_animationController.StopRunAnimation();
                
                //_animationController.PlayIdleAnimation();
                return;
            }

            transform.forward = movementVector;

            movementVector += Physics.gravity;

            Vector3 deltaPosition = movementVector * (_model.Speed * Time.deltaTime);

            //_animationController.PlayRunAnimation();
            _view.Move(deltaPosition);
        }

        private bool TryGetPlayerMovementVector(out Vector3 movementVector)
        {
            movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude < 0.1f) //TODO : вынести в конфиг 0.5f 
                return false;

            movementVector = _camera.transform.TransformDirection(_inputService.Axis);
            movementVector.y = 0;
            movementVector.Normalize();

            return true;
        }
    }
}