using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Data
{
    public static class DataModule
    {
        [JsonProperty("0")] private static Dictionary<Type, UserDatabase> _databases = new();
        private static string _savedJson = "";

        public static T GetModule<T>() where T : UserDatabase, new()
        {
            return _GetModule<T>();
        }

        private static T _GetModule<T>() where T : UserDatabase, new()
        {
            if (_databases.TryGetValue(typeof(T), out var constructor)) return (T)constructor;
            constructor = new T();
            _databases.Add(typeof(T), constructor);

            return (T)constructor;
        }

        public static void SaveAll()
        {
            var jsons = _databases.Values.Select(data => data.GetDataJson());
            _savedJson = "[" + string.Join(",", jsons) + "]";
            PlayerPrefs.SetString("all_data", _savedJson);
        }

        public static void LoadAll()
        {
            _savedJson = PlayerPrefs.GetString("all_data");
            if (_savedJson == "") return;
            var jsons = JArray.Parse(_savedJson);
            foreach (var json in jsons)
            {
                var type = Type.GetType((string)json["type"] ?? string.Empty);
                if (type == null || !_databases.TryGetValue(type, out var constructor)) continue;
                constructor.SynchronizeData(json.ToString());
            }
        }
    }
}