using System;
using Sources.Game.Common.Mvp.Interfaces.IPlayerMovement;
using UniCtor.Attributes;
using UnityEngine;

namespace Sources.Game.Common.Mvp.Implementation.PlayerMovement
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class HeroMove : MonoBehaviour, IPlayerMovementView
    {
        [SerializeField] private CharacterController _characterController;
        private PlayerMovementController _controller;

        private void Update()
        {
            _controller.MovePlayer(transform);
        }

        [Constructor]
        private void Construct(PlayerMovementController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
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
        //TODO : У view нет пресентора это нормально ??
    }
}