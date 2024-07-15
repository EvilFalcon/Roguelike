using System;
using Sources.Game.BoundedContexts.Heroes.Implementation.Controllers;
using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.IDontCno;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.View
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class HeroMovementView : MonoBehaviour, IPlayerMovementView, IHeroTransform, IView
    {
        [SerializeField] private CharacterController _characterController;
        private HeroMovementController _controller;

        public Transform Transform => transform;
        // TODO : убрать костыль

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        public void Move(Vector3 direction)
        {
            _characterController.Move(direction);
        }
        
        public void Construct(HeroMovementController controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            _controller = controller;
        }
    }
}