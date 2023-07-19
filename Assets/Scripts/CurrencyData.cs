using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public class CurrencyData : Database
    {
        [JsonProperty("currency")] private CurrencyInfo _data;

        public CurrencyData()
        {
            Load();
        }

        protected override void Save()
        {
            PlayerPrefs.SetString("currency", JsonConvert.SerializeObject(_data));
        }

        protected sealed override void Load()
        {
            _data = JsonConvert.DeserializeObject<CurrencyInfo>(PlayerPrefs.GetString("currency")) ?? new CurrencyInfo()
            {
                Coin = 1,
                Gem = 1,
            };
        }

        public override string GetDataJson()
        {
            return JsonConvert.SerializeObject(_data);
        }

        public override void SynchronizeData(string data)
        {
            PlayerPrefs.SetString("currency", data);
            _data = JsonConvert.DeserializeObject<CurrencyInfo>(data);
        }

        public CurrencyInfo GetCurrency()
        {
            return _data;
        }

        public void SetCoin(int coin)
        {
            _data.Coin = coin;
            Save();
        }

        public void SetGem(int gem)
        {
            _data.Gem = gem;
            Save();
        }
    }

    public class CurrencyInfo
    {
        [JsonProperty("0")] public int Coin;
        [JsonProperty("1")] public int Gem;
    }
}