using Sources.Game.BoundedContexts.Heroes.Implementation.Controllers;
using Sources.Game.Common.Mvp;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.View
{
    public class HeroView : ViewBase
    {
        [SerializeField] private Slider _experienceSlider;
        [SerializeField] private Slider _healthSlider;
        
        private HeroPresenter _presenter;

        protected override void Enable()
        {
            _presenter.Enable();
        }

        protected override void Disable()
        {
            _presenter.Disable();
        }

        public void Construct(HeroPresenter presenter)
        {
            _presenter = presenter;
        }
        
        public void SetExperience(int experience)
        {
            _experienceSlider.value = experience;
        }
        
        public void SetHealth(int health)
        {
            _healthSlider.value = health;
        }
    }
}