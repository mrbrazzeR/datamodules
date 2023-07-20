using UnityEngine;

namespace Data
{
    public class TestData : MonoBehaviour
    {
        private void Awake()
        {
            var data = DataModule.GetModule<StatsUserData>();
            Debug.Log(data.LoadStats().Health);
        }
    }
}