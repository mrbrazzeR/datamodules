using System;
using Newtonsoft.Json;

namespace Database
{
    public sealed class StatsUserData : UserDatabase
    {
        [JsonProperty("stats")] private StatsInfo _stats;
        [JsonProperty("type")] public string Type { get; set; } = typeof(StatsUserData).FullName;

        public StatsUserData()
        {
            Load();
        }

        private void Save()
        {
            OnDataChanged();
        }

        private void Load()
        {
            _stats ??= new StatsInfo();
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