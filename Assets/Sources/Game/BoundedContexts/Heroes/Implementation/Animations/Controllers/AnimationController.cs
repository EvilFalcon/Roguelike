using System;
using Sources.Game.BoundedContexts.Heroes.Implementation.Animations.View;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Animations.Controllers
{
    public class AnimationController
    {
        private readonly AnimationView _view;
        private readonly AnimationModel _madel;

        public AnimationController(AnimationView view,AnimationModel madel )
        {
            _view = view;
            _madel = madel ?? throw new ArgumentNullException(nameof(madel));
        }

        private string _currentAnimationState;

        public void PlayRunAnimation()
        {

        }

        public void PlayIdleAnimation()
        {
            throw new System.NotImplementedException();
        }

        public void PlayAttackAnimation()
        {
            throw new System.NotImplementedException();
        }

        public void StopIdleAnimation()
        {
            throw new System.NotImplementedException();
        }

        public void StopRunAnimation()
        {
            throw new System.NotImplementedException();
        }
    }

    public class AnimationModel
    {
        public AnimationModel(string run, string idle, string attack)
        {
            Run = Animator.StringToHash(run);
            Idle = Animator.StringToHash(idle);
            Attack = Animator.StringToHash(attack);
          
        }

        public int Run { get; set; }
        public int Idle { get; set; }
        public int Attack { get; set; }
        
    }
}