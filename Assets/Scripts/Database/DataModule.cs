using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Database
{
    public static class DataModule
    {
        [JsonProperty("0")] private static Dictionary<Type, UserDatabase> databases = new();
        private static string savedJson = "";

        public static T GetModule<T>() where T : UserDatabase, new()
        {
            return _GetModule<T>();
        }

        private static T _GetModule<T>() where T : UserDatabase, new()
        {
            if (databases.TryGetValue(typeof(T), out var constructor))
            {
                return (T)constructor;
            }

            constructor = new T();
            databases.Add(typeof(T), constructor);
            constructor.DataChanged += SynchronizeDataChange<T>;
            return (T)constructor;
        }

        private static void SynchronizeDataChange<T>(object sender, EventArgs e) where T : UserDatabase
        {
            if (sender is not T database) return;
            var type = typeof(T);
            if (databases.ContainsKey(type))
            {
                databases[type] = database;
            }
        }

        public static void SaveAll()
        {
            var jsons = databases.Values.Select(data => data.GetDataJson());
            savedJson = "[" + string.Join(",", jsons) + "]";
            PlayerPrefs.SetString("all_data", savedJson);
        }

        public static void LoadAll()
        {
            savedJson = PlayerPrefs.GetString("all_data");
            if (savedJson == "") return;
            var jsons = JArray.Parse(savedJson);
            foreach (var json in jsons)
            {
                var type = Type.GetType((string)json["type"] ?? string.Empty);
                if (type == null) continue;
                if (!databases.TryGetValue(type, out var constructor))
                {
                    constructor = (UserDatabase)Activator.CreateInstance(type);
                    databases[type] = constructor;
                }

                constructor.SynchronizeData(json.ToString());
            }
        }
    }
}