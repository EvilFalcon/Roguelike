using System;
using System.IO;
using Newtonsoft.Json;
using Sources.Game.DataTransferObjects.Interfaces;
using UnityEngine;

namespace Sources.Game.DataTransferObjects.Implementation.Services
{
    public class SaveLoadedService : ISaveLoadedServices, ILoadDataFiles
    {
        private readonly SaveLoadPlayerPrefs _saveLoadPlayerPrefs;

        public SaveLoadedService(SaveLoadPlayerPrefs saveLoadPlayerPrefs)
        {
            _saveLoadPlayerPrefs = saveLoadPlayerPrefs ?? throw new ArgumentNullException(nameof(saveLoadPlayerPrefs));
        }

        public T Load<T>(string key)  
        {
            if (_saveLoadPlayerPrefs.Load(key, out string json) == false)
                json = Resources.Load<TextAsset>($"Data/{key}").text;

            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Save(string key, object @object) =>
            _saveLoadPlayerPrefs.Save(key, @object);

        public T Load<T>(T @object, string postfix = "") => 
            Load<T>($"{postfix}{typeof(T).Name}");

        public void SystemCreateJson(object data, string postfix = "") //TODO: после добавления файлов в ресурсы этот метод не нужен
        {
            var extension = ".json";
            var path = @"F:\Roguelike\Assets\Resources\Data";
            var fileName = data.GetType().Name;
            var jsonString = JsonConvert.SerializeObject(data);
            var file = Path.Combine(path, fileName + extension);

            if (File.Exists(file) == false)
            {
                using (File.Create(file));
            }

            File.WriteAllText(file, jsonString);
        }
    }

    public interface ISaveLoadedServices
    {
        T Load<T>(string key);
        T Load<T>(T @object, string postfix = "");
        void Save(string key, object @object);
    }
}