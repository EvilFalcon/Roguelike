using System.IO;
using Newtonsoft.Json;
using UnityEditor.AddressableAssets.Build.Layout;
using UnityEngine;

namespace Sources.Game.DataTransferObjects.Implementation.Services
{
    public class DataSaveLoadedServices
    {
        public T LoadData<T>(T @object)
        {
            string json = Resources.Load<TextAsset>($"Data/{@object.GetType().Name}").text;
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void SaveData(object data)
        {
            var extension = ".Json";
            var path = @"F:\Roguelike\Assets\Resources\Data";
            var fileName = data.GetType().Name;
            var jsonString = JsonConvert.SerializeObject(data);
            var file = Path.Combine(path, fileName + extension);

            if (File.Exists(file) == false)
            {
                using (File.Create(file)) ;
            }

            File.WriteAllText(file, jsonString);
        }
    }
}