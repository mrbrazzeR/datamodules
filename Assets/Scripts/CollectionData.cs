using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public class CollectionData : UserDatabase
    {
        [JsonProperty("currency")] private CollectionInfo _data = new();
        [JsonProperty("type")] public string Type { get; set; } = typeof(CollectionData).FullName;

        public CollectionData()
        {
            Load();
        }

        private void Save()
        {
            OnDataChanged();
        }

        private void Load()
        {
        }

        public override string GetDataJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override void SynchronizeData(string data)
        {
            var startIndex = data.IndexOf("{", data.IndexOf("{", StringComparison.Ordinal) + 1,
                StringComparison.Ordinal);
            var endIndex = data.IndexOf("}", startIndex, StringComparison.Ordinal);
            var result = data.Substring(startIndex, endIndex - startIndex + 1);
            _data = JsonConvert.DeserializeObject<CollectionInfo>(result);
            OnDataChanged();
            Save();
        }

        public void AddData(int id)
        {
            _data.ID.Add(id);
            OnDataChanged();
            Save();
        }
    }

    public class CollectionInfo
    {
        [JsonProperty("0")] public List<int> ID;
    }
}