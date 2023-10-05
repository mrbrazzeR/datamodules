using Database;
using UnityEngine;

namespace Data
{
    public class DatabaseLoading : MonoBehaviour
    {
        private void Awake()
        {
            var database = FindObjectOfType<DatabaseLoading>();
            if (database != null && database != this)
            {
                Destroy(database.gameObject);
            }

            DontDestroyOnLoad(this);
            DataModule.LoadAll();
        }

        private void OnApplicationQuit()
        {
            DataModule.SaveAll();
        }
    }
}