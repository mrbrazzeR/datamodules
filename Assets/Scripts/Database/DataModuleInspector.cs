using System;
using System.Linq;
using Data;
using UnityEngine;

public class DataModuleInspector : MonoBehaviour
{
    [HideInInspector] public int selectedIndex;
    [HideInInspector] public Type[] databaseType;

    private void OnEnable()
    {
        // Get all types that inherit from UserDataBase
        databaseType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsSubclassOf(typeof(UserDatabase)))
            .ToArray();

        // Get the names of the types
        var typeNames = databaseType.Select(t => t.Name).ToArray();
    }
}