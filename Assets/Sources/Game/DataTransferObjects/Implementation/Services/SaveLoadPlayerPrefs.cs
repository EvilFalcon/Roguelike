using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Sources.Game.DataTransferObjects.Implementation.Services
{
    public class SaveLoadPlayerPrefs
    {
        public void Save(string key, object @object)
        {
            string json = JsonConvert.SerializeObject(@object);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }

        public bool Load(string key, out string json)
        {
            if (PlayerPrefs.HasKey(key))
            {
                json = PlayerPrefs.GetString(key);
                return true;
            }

            json = "";
            return false;
        }

        public void Remove(string key) =>
            PlayerPrefs.GetString(key, "");
    }
}