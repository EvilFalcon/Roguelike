using System;
using System.Collections.Generic;
using Sources.Game.Common.Models.Exceptions;

namespace Sources.Game.Common.Models
{
    // public class ModelRepository
    // {
    //     private readonly ModelObserver _observer;
    //     private readonly Dictionary<Type, IModel> _models = new Dictionary<Type, IModel>();
    //
    //     public ModelRepository(ModelObserver observer) =>
    //         _observer = observer ?? throw new ArgumentNullException(nameof(observer));
    //
    //     public void RemoveModel(Type type)
    //     {
    //         if (_models.TryGetValue(type, out var model) == false)
    //             throw new ModelIsRegisteredException($"This model is not registered {type}");
    //
    //         _observer.OnUnListen(model);
    //         _models.Remove(type);
    //     }
    //
    //     public void ClearModels()
    //     {
    //         foreach (var model in _models)
    //         {
    //             _observer.OnUnListen(model.Value);
    //         }
    //
    //         _models.Clear();
    //     }
    //
    //     public void AddModel(IModel model)
    //     {
    //         if (_models.ContainsKey(model.GetType()))
    //             throw new ModelIsRegisteredException($"This model is already registered {model.GetType()}");
    //
    //         _models.Add(model.GetType(), model);
    //         _observer.OnListen(model);
    //     }
    // }
    //
    // public interface IModel : ISaveModel
    //
    // {
    // }
}