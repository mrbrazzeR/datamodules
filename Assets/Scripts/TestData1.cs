using UnityEngine;

namespace Data
{
    public class TestData1:MonoBehaviour
    {
        private void Awake()
        {
            var currency = DataModule.GetModule<CurrencyData>();
            Debug.Log(currency.GetCurrency().Coin);
            currency.SetCoin(300);
            Debug.Log(currency.GetCurrency().Coin);
        }
    }
}