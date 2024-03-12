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
        //TODO : У view нет пресентора это нормально ??
    }
}