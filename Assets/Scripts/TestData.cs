using UnityEngine;

namespace Data
{
    public class TestData : MonoBehaviour
    {
        private void Awake()
        {
            var data = DataModule.GetModule<StatsDatabase>();
            Debug.Log(data.LoadStats().Health);

            var currency = DataModule.GetModule<CurrencyData>();
            Debug.Log(currency.GetCurrency().Coin);
            currency.SetCoin(111);
            Debug.Log(currency.GetCurrency().Coin);
        }
    }
}