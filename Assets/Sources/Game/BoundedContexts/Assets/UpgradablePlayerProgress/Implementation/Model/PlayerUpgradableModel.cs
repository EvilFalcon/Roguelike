using System.Collections.Generic;
using Sources.Game.DataTransferObjects.Implementation.DTO.Upgradable;
using Sources.Game.DataTransferObjects.Interfaces;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model
{
    public class PlayerUpgradableModel : IDataFiels
    {
        private readonly PlayerUpgradableDto _playerUpgradableDto;
        private int _currentsyLivelAttackDelay = 0;
        private int _currentsyLivelHealthModifier = 0;
        private int _currentsyLivelDamageModifiery = 0;
        private int _currentsyLivelArmorModifier = 0;

        public PlayerUpgradableModel(PlayerUpgradableDto playerUpgradableDto)
        {
            _playerUpgradableDto = playerUpgradableDto;
        }

      //  public DamageModifierDTO DamageModifier {
      //      get
      //      {
      //          int damageModifier = _playerUpgradableDto.DamageModifier[_currentsyLivelDamageModifiery];
      //          _currentsyLivelDamageModifiery++;
      //          return damageModifier;
      //      }
      //      
      //  }
    }
}