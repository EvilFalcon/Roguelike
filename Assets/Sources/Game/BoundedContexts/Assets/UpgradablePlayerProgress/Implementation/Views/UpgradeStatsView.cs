using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Presenter;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces;
using Sources.Game.Common.Mvp.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Views
{
    public class UpgradeStatsView : MonoBehaviour, IUpgradeStatsView,IView
    {
        [SerializeField] private Button _upgradableHealth;
        [SerializeField] private Button _upgradableAttack;
        [SerializeField] private Button _upgradableAttackDelay;
        [SerializeField] private Button _upgradableArmor;
        [SerializeField] private Button _upgradablePanelClose;

        [SerializeField] private TextMeshProUGUI _textUpgradableHealth;
        [SerializeField] private TextMeshProUGUI _textUpgradableAttack;
        [SerializeField] private TextMeshProUGUI _textUpgradableAttackDelay;
        [SerializeField] private TextMeshProUGUI _textUpgradableArmor;

        private UpgradeStatsPresenter _presenter;

        public void Show()
        {
            _upgradableHealth.onClick.AddListener(OnUpgradableHealthButtonClick);
            _upgradableAttack.onClick.AddListener(OnUpgradableAttackButtonClick);
            _upgradableAttackDelay.onClick.AddListener(OnUpgradableAttackDelayButtonClick);
            _upgradableArmor.onClick.AddListener(OnUpgradableArmorButtonClick);
            
            _upgradablePanelClose.onClick.AddListener(OnCloseButtonClick);
            gameObject.SetActive(true);
            _presenter.Enable();
        }

        public void Hide()
        {
            _upgradableHealth.onClick.RemoveListener(OnUpgradableHealthButtonClick);
            _upgradableAttack.onClick.RemoveListener(OnUpgradableAttackButtonClick);
            _upgradableAttackDelay.onClick.RemoveListener(OnUpgradableAttackDelayButtonClick);
            _upgradableArmor.onClick.RemoveListener(OnUpgradableArmorButtonClick);
            _upgradablePanelClose.onClick.RemoveListener(OnCloseButtonClick);
            gameObject.SetActive(false);
            _presenter.Disable();
        }

        private void OnCloseButtonClick()
        {
            _presenter.CloseViewPanel();
        }

        public void Construct(UpgradeStatsPresenter presenter) =>
            _presenter = presenter;

        public void SetTexts(string health, string attack, string attackDelay, string armor)
        {
            _textUpgradableHealth.text = health;
            _textUpgradableAttack.text = attack;
            _textUpgradableAttackDelay.text = attackDelay;
            _textUpgradableArmor.text = armor;
        }

        private void OnUpgradableArmorButtonClick() =>
            _presenter.UpgradeArmor();

        private void OnUpgradableAttackDelayButtonClick() =>
            _presenter.UpgradeAttackDelay();

        private void OnUpgradableAttackButtonClick() =>
            _presenter.UpgradeAttack();

        private void OnUpgradableHealthButtonClick() =>
            _presenter.UpgradeHealth();
    }
}