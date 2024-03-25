using System.IO;
using Newtonsoft.Json;
using Sources.Game.DataTransferObjects.Interfaces;
using UnityEngine;

namespace Sources.Game.DataTransferObjects.Implementation.Services
{
    public class DataSaveLoadedGameProgressServices : ISaveLoadedGameProgresServices, ILoadDataFiles
    {
        public T LoadData<T>(T @object)
        {
            string json = Resources.Load<TextAsset>($"Data/{@object.GetType().Name}").text;
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void SaveData(object data)
        {
            throw new System.NotImplementedException();
        }

        public T LoadData<T>(T @object, string postfix)
        {
            string json = Resources.Load<TextAsset>($"Data/{postfix}{typeof(T).Name}").text;
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void SaveData(object data, string postfix = "")
        {
            var extension = ".json";
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

    public interface ISaveLoadedGameProgresServices
    {
        T LoadData<T>(T @object);
        T LoadData<T>(T @object, string postfix);
        void SaveData(object data);
    }
}