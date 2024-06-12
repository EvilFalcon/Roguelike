using Sources.Game.IDontCno;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Animations.View
{
    public class AnimationView : MonoBehaviour, IAnimationView
    {
        [SerializeField] private Animator _animator;

        public void Show()
        {
            throw new System.NotImplementedException();
        }

        public void Hide()
        {
            throw new System.NotImplementedException();
        }
        
        public void SetAnimation(int hash, bool value)
        {
            _animator.SetBool(hash,value);
        }
    }

    public interface IAnimationView : IView
    {
    }

    public interface IHeroAnimationView : IView
    {
    }
}