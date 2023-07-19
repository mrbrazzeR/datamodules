using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public class StatsUserDatabase : UserDatabase
    {
        [JsonProperty("stats")]private StatsInfo _stats;

        public StatsUserDatabase()
        {
            Load();
        }

        protected override void Save()
        {
            PlayerPrefs.SetString("stats", JsonConvert.SerializeObject(_stats));
        }

        protected sealed override void Load()
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
            return JsonConvert.SerializeObject(_stats);
        }

        public override void SynchronizeData(string data)
        {
            PlayerPrefs.SetString("stats", data);
            _stats = JsonConvert.DeserializeObject<StatsInfo>(data);
        }

        public StatsInfo LoadStats()
        {
            Load();
            return _stats;
        }

        public void ChangeHealth(int stats)
        {
            _stats.Health = stats;
            Save();
        }

        public void ChangeDamage(int stats)
        {
            _stats.Damage = stats;
            Save();
        }

        public void ChangeSpeed(int stats)
        {
            _stats.Speed = stats;
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