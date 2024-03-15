using Newtonsoft.Json;
using Sources.Game.DataTransferObjects.Interfaces;
using UnityEngine;

namespace Sources.Game.DataTransferObjects.Implementation.Services
{
    public class DataSaveLoadedServices
    {
        public T LoadData<T>() where T : class, IDataFiels
        {
            var json = Resources.Load<TextAsset>("Data").text;
           return JsonConvert.DeserializeObject<T>(json); 
            
        }
    }
    
   // public void SaveData<T>( T data) where T : class,  IDataFiels
   // {
   //     var json = JsonConvert.SerializeObject(data);
   //     JsonConvert.SerializeObject()
   // }
}