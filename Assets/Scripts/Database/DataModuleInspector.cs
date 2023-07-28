using System;
using System.Linq;
using Data;
using UnityEngine;

public class DataModuleInspector : MonoBehaviour
{
    public int selectedIndex;
    [HideInInspector] public Type[] databaseType = { };


    private void Awake()
    {
        databaseType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsSubclassOf(typeof(UserDatabase)))
            .ToArray();
        var instance = (UserDatabase)Activator.CreateInstance(databaseType[selectedIndex]);
        Debug.Log(instance.GetDataJson());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(databaseType[selectedIndex]);
        }
    }
}