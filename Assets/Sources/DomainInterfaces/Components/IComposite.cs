using System;
using DomainInterfaces.Composite.Component;

namespace DomainInterfaces.Composite
{
    public interface IComposite
    {
        event Action BeforeComponentsChanged;
        event Action AfterComponentsChanged;
        
        bool TryGetComponent(Type type, out IComponent component);
        bool TryGetComponent<T>(out T component) where T : IComponent;
    }
}