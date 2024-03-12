using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.Common.Mvp.Interfaces.IPlayerMovement;
using UnityEngine;

namespace Sources.Game.Common.Mvp.Implementation.PlayerMovement
{
    public class PlayerMovementPresenter
    {
        private readonly IPlayer _model;
        private readonly IPlayerMovementView _view;
        private readonly IInputService _inputService;
        private readonly Camera _camera;

        public PlayerMovementPresenter(IPlayerMovementView view, IInputService inputService)
        {
            //_model = model; //TODO : Стоит ли брать информацию о позиции персонажа из компонентов модели или стоит это брать со View?
            _view = view;
            _inputService = inputService;
            _camera = Camera.main; //TODO : вынести в CameraService? 
        }  

        public void Enabled()
        {
            _view.Show();
        }

        public void Disabled()
        {
            _view.Hide();
        }

        public void MovePlayer(Transform transform)
        {
            if (TryGetPlayerMovementVector(out Vector3 movementVector) == false)
                return;

            transform.forward = movementVector;

            movementVector += Physics.gravity;

            Vector3 deltaPosition = movementVector * (4 * Time.deltaTime); //TODO : вынести в конфиг 4. брать из модели?

            _view.Move(deltaPosition);
        }

        private bool TryGetPlayerMovementVector(out Vector3 movementVector)
        {
            movementVector = Vector3.zero;

            if ((_inputService.Axis.sqrMagnitude < 0.01f)) //TODO : вынести в конфиг 0.01f 
                return false;

            movementVector = _camera.transform.TransformDirection(_inputService.Axis);
            movementVector.y = 0;
            movementVector.Normalize();

            return true;
        }
    }
}