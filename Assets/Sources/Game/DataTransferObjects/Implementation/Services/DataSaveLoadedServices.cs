using Newtonsoft.Json;
using UnityEngine;

namespace Sources.Game.DataTransferObjects.Implementation.Services
{
    public class DataSaveLoadedServices
    {
        public T LoadData<T>()
        {
            var json = Resources.Load<TextAsset>($"Data{nameof(T)}").text;
            return JsonConvert.DeserializeObject<T>(json);
        }

       // public void SaveData<T>(T data) where T : class, IDataFiels
       // {
       //     var json = JsonConvert.SerializeObject(data);
       //      JsonConvert.SerializeObject(data);
       // }
    }
}