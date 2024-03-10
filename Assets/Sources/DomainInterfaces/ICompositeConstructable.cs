using DomainInterfaces.Composite.Component;

namespace DomainInterfaces
{
    public interface ICompositeConstructable
    {
        void AddComponent(IComponent component);
        void RemoveComponent(IComponent component);
    }
}