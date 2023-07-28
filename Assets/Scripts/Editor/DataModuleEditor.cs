using System;
using System.Linq;
using Data;
using UnityEditor;

namespace MyEditor
{
    [CustomEditor(typeof(DataModuleInspector))]
    public class DataModuleEditor : Editor
    {
        private int _selectedIndex;
        private Type[] _types;


        private void OnEnable()
        {
            DataModuleInspector dataModule = (DataModuleInspector)target;
            // Get all types that inherit from UserDataBase
            dataModule.databaseType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(UserDatabase)))
                .ToArray();
        }

        public override void OnInspectorGUI()
        {
            // Call the base method
            base.OnInspectorGUI();

            DataModuleInspector dataModule = (DataModuleInspector)target;
            // Get all types that inherit from BaseClass
            _types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(UserDatabase)))
                .ToArray();

            // Get the names of the types
            var typeNames = _types.Select(t => t.Name).ToArray();

            // Create a dropdown menu with the type names
            _selectedIndex = EditorGUILayout.Popup("Type", _selectedIndex, typeNames);
            dataModule.selectedIndex = _selectedIndex;
            // Get the selected type
        }
    }
}