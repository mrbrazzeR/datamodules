﻿using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public sealed class CurrencyData : UserDatabase
    {
        [JsonProperty("currency")] private CurrencyInfo _data;
        [JsonProperty("type")]
        public string Type { get; set; } = typeof(CurrencyData).FullName;

        public CurrencyData()
        {
            Load();
        }

        private void Save()
        {
            PlayerPrefs.SetString("currency", JsonConvert.SerializeObject(_data));
        }

        private void Load()
        {
            _data = JsonConvert.DeserializeObject<CurrencyInfo>(PlayerPrefs.GetString("currency")) ?? new CurrencyInfo()
            {
                Coin = 1,
                Gem = 1,
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
            _data = JsonConvert.DeserializeObject<CurrencyInfo>(result);
            Save();
        }

        public CurrencyInfo GetCurrency()
        {
            return _data;
        }

        public void SetCoin(int coin)
        {
            _data.Coin = coin;
            OnDataChanged();
            Save();
        }

        public void SetGem(int gem)
        {
            _data.Gem = gem;
            OnDataChanged();
            Save();
        }
    }

    public class CurrencyInfo
    {
        [JsonProperty("0")] public int Coin;
        [JsonProperty("1")] public int Gem;
    }
}