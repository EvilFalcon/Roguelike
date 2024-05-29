using System;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Presenter;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Services;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Views;
using Sources.Game.BoundedContexts.Localizations.Implementation.Services;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Factories
{
    public class UpgradeStatsPresenterFactory
    {
        private readonly LocalizationService _localizationService;
        private readonly UpgradableService _upgradableService;
        private readonly IFormService _formService;

        public UpgradeStatsPresenterFactory
        (
            LocalizationService localizationService,
            UpgradableService upgradableService,
            IFormService formService
        )
        {
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _upgradableService = upgradableService ?? throw new ArgumentNullException(nameof(upgradableService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public UpgradeStatsPresenter Create(UpgradeStatsView view, UpgradeStatsModel model, IPlayer player)
        {
            return new UpgradeStatsPresenter(view, model, player, _localizationService.Localization, _upgradableService, _formService);
        }
    }
}