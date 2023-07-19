using System;
using UnityEngine;

namespace Data
{
    public class DatabaseLoading:MonoBehaviour
    {
        private void Awake()
        {
            DataModule.LoadAll();
        }

        private void OnApplicationQuit()
        {
            DataModule.SaveAll();
        }
    }
}