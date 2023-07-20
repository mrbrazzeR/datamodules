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
            var data2 = DataModule.GetModule<CollectionData>();
        }
    }
}