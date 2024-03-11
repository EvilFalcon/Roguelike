using System;
using Controllers.PlayerMovement;
using PresentationInterfaces.IPlayerMovement;
using UniCtor.Attributes;
using UnityEngine;

namespace Presentation.PlayerMovementView
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMove : MonoBehaviour, IPlayerMovementView
    {
        [SerializeField] private CharacterController _characterController;
        private PlayerMovementPresenter _presenter;

        private void Update()
        {
            _presenter.MovePlayer(transform);
        }

        [Constructor]
        private void Construct(PlayerMovementPresenter presenter)
        {
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Move(Vector3 direction)
        {
            _characterController.Move(direction); //TODO : NullReferenceException как пофиксить.
        }
        ///TODO : У view нет пресентора это нормально ??
    }
}