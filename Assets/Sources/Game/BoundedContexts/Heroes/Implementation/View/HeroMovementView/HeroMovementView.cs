using System;
using Sources.Game.BoundedContexts.Heroes.Implementation.Controllers;
using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.IDontCno;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.View.HeroMovementView
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class HeroMovementView : MonoBehaviour, IPlayerMovementView, IHeroTransform, IView
    {
        [SerializeField] private CharacterController _characterController;
        private HeroMovementController _controller;

        public Transform Transform => transform;

        private void Update() =>
            _controller.MovePlayer(transform);

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        public void Move(Vector3 direction) =>
            _characterController.Move(direction); //TODO : NullReferenceException как пофиксить.

        //TODO : У view нет пресентора это нормально ??
        public void Construct(HeroMovementController controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            _controller = controller;
        }
    }
}