using UnityEngine;

namespace Data
{
    public class TestData : MonoBehaviour
    {
        private void Awake()
        {
            var data = DataModule.GetModule<StatsUserData>();
            Debug.Log(data.LoadStats().Health);
            data.ChangeHealth(400);
            var currency = DataModule.GetModule<CurrencyData>();
            Debug.Log(currency.GetCurrency().Coin);
            currency.SetCoin(300);
            Debug.Log(currency.GetCurrency().Coin);
        }
    }
}