﻿using System;
using System.Collections.Generic;
using DomainInterfaces;
using DomainInterfaces.Composite;
using DomainInterfaces.Composite.Component;

namespace Domain.Component
{
    public class Composite : IComposite, ICompositeConstructable
    {
        private readonly List<IComponent> _components = new List<IComponent>();

        public event Action BeforeComponentsChanged;
        public event Action AfterComponentsChanged;

        public bool TryGetComponent(Type type, out IComponent component)
        {
            foreach (IComponent currentComponent in _components)
            {
                if (currentComponent.GetType() == type)
                {
                    component = currentComponent;

                    return true;
                }
            }

            component = default;

            return false;
        }

        public bool TryGetComponent<T>(out T component) where T : IComponent
        {
            foreach (IComponent currentComponent in _components)
            {
                if (currentComponent.GetType() == typeof(T))
                {
                    component = (T)currentComponent;

                    return true;
                }
            }

            foreach (IComponent currentComponent in _components)
            {
                if (currentComponent is T typedComponent)
                {
                    component = typedComponent;

                    return true;
                }
            }
            
            component = default;

            return false;
        }

        public void AddComponent(IComponent component)
        {
            BeforeComponentsChanged?.Invoke();

            if (_components.Contains(component))
                return;

            _components.Add(component);
            AfterComponentsChanged?.Invoke();
        }

        public void RemoveComponent(IComponent component)
        {
            BeforeComponentsChanged?.Invoke();
            _components.Remove(component);
            AfterComponentsChanged?.Invoke();
        }
    }
}