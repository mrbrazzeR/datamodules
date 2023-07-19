using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public sealed class StatsUserDatabase : UserDatabase
    {
        [JsonProperty("stats")] private StatsInfo _stats;
        [JsonProperty("type")] public string Type { get; set; } = typeof(StatsUserDatabase).FullName;

        public StatsUserDatabase()
        {
            Load();
        }

        private void Save()
        {
            PlayerPrefs.SetString("stats", JsonConvert.SerializeObject(_stats));
        }

        private void Load()
        {
            _stats = JsonConvert.DeserializeObject<StatsInfo>(PlayerPrefs.GetString("stats")) ?? new StatsInfo()
            {
                Health = 1,
                Damage = 1,
                Speed = 1
            };
        }

        public override string GetDataJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override void SynchronizeData(string data)
        {
            var startIndex = data.IndexOf("{", data.IndexOf("{", StringComparison.Ordinal) + 1, StringComparison.Ordinal);
            var endIndex = data.IndexOf("}", startIndex, StringComparison.Ordinal);
            var result = data.Substring(startIndex, endIndex - startIndex + 1);
            _stats = JsonConvert.DeserializeObject<StatsInfo>(result);

            Save();
        }

        public StatsInfo LoadStats()
        {
            Load();
            return _stats;
        }

        public void ChangeHealth(int stats)
        {
            _stats.Health = stats;
            OnDataChanged();
            Save();
        }

        public void ChangeDamage(int stats)
        {
            _stats.Damage = stats;
            OnDataChanged();
            Save();
        }

        public void ChangeSpeed(int stats)
        {
            _stats.Speed = stats;
            OnDataChanged();
            Save();
        }
    }

    public class StatsInfo
    {
        [JsonProperty("0")] public int Health;
        [JsonProperty("1")] public int Damage;
        [JsonProperty("2")] public int Speed;
    }
}