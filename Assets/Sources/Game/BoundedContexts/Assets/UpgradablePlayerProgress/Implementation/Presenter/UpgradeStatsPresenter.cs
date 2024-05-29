using System;
using System.ComponentModel;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Exceptions;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Services;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Views;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces;
using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.Players.Interfaces;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Presenter
{
    public class UpgradeStatsPresenter : IUpgradeStatsPresenter
    {
        private readonly UpgradeStatsView _view;
        private readonly UpgradeStatsModel _upgradeStatsModel;
        private readonly IPlayer _player;
        private readonly LocalizationModel _localizationModel;
        private readonly UpgradableService _upgradableService;

        public UpgradeStatsPresenter
        (
            UpgradeStatsView view,
            UpgradeStatsModel upgradeStatsModel,
            IPlayer player,
            LocalizationModel localizationModel,
            UpgradableService upgradableService
        )
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _upgradeStatsModel = upgradeStatsModel ?? throw new ArgumentNullException(nameof(upgradeStatsModel));
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _localizationModel = localizationModel ?? throw new ArgumentNullException(nameof(localizationModel));
            _upgradableService = upgradableService ?? throw new ArgumentNullException(nameof(upgradableService));
        }

        public void Enable()
        {
            _localizationModel.PropertyChanged += OnLocalization;
        }

        public void Disable()
        {
            _localizationModel.PropertyChanged -= OnLocalization;
        }

        public void UpgradeArmor()
        {
            try
            {
                _upgradableService.UpgradeArmor();
            }
            catch (ExceptionImpossibleTransaction)
            {
                Console.WriteLine("not enough money" + _player.Money + " " + _upgradeStatsModel.CurrentArmorLevel);
            }
        }

        public void UpgradeAttackDelay()
        {
            try
            {
                _upgradableService.UpgradeAttackDelay();
            }
            catch (ExceptionImpossibleTransaction)
            {
                Console.WriteLine("not enough money" + _player.Money + " " + _upgradeStatsModel.CurrentAttackDelay);
            }
        }

        public void UpgradeAttack()
        {
            try
            {
                _upgradableService.UpgradeAttack();
            }
            catch (ExceptionImpossibleTransaction)
            {
                Console.WriteLine("not enough money" + _player.Money + " " + _upgradeStatsModel.CurrentAttackLevel);
            }
        }

        public void UpgradeHealth()
        {
            try
            {
                _upgradableService.UpgradeHealth();
            }
            catch (ExceptionImpossibleTransaction)
            {
                Console.WriteLine("not enough money" + _player.Money + " " + _upgradeStatsModel.CurrentHealthLevel);
            }
        }

        private void OnLocalization(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LocalizationModel.Language))
            {
                _view.SetTexts
                (
                    _localizationModel.UpgradablePlayerStats["UpgradableHealth"],
                    _localizationModel.UpgradablePlayerStats["UpgradableAttack"],
                    _localizationModel.UpgradablePlayerStats["UpgradableAttackDelay"],
                    _localizationModel.UpgradablePlayerStats["UpgradableArmor"]
                );
            }
        }
    }
}