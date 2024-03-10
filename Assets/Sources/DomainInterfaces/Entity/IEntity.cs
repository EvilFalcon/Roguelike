using DomainInterfaces.Entity.EntityType;

namespace DomainInterfaces.Entity
{
    public interface IEntity
    {
        int Id { get; }
        
        IEntityType Type { get; }
    }
}