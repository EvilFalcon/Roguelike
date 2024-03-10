using DomainInterfaces.Components.Damageable;

namespace Domain.Component.Damageable
{
    public class DamageableComponent : IDamageableComponent
    {

        public void TakeDamage<T>(int damage) where T : IDamageType
        {
            
              
        }
    }
}