﻿using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Database
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
            if (_databases.TryGetValue(typeof(T), out var constructor))
            {
                return (T)constructor;
            }

            constructor = new T();
            _databases.Add(typeof(T), constructor);
            constructor.DataChanged += SynchronizeDataChange<T>;
            return (T)constructor;
        }

        private static void SynchronizeDataChange<T>(object sender, EventArgs e) where T : UserDatabase
        {
            if (sender is not T database) return;
            var type = typeof(T);
            if (_databases.ContainsKey(type))
            {
                _databases[type] = database;
            }
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
                if (type == null) continue;
                if (!_databases.TryGetValue(type, out var constructor))
                {
                    constructor = (UserDatabase)Activator.CreateInstance(type);
                    _databases[type] = constructor;
                }

                constructor.SynchronizeData(json.ToString());
            }
        }
    }
}