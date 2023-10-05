using System;
using UnityEngine;

namespace PoolCustomer
{
    public class PoolTest : MonoBehaviour
    {
        [SerializeField] private ChildTest testPrefab;
        [SerializeField] private Enemy enemy;

        private void Start()
        {
            var obj = ObjectPoolManager.Instance.GetChildObject(testPrefab);
            obj.transform.SetParent(transform);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var obj = ObjectPoolManager.Instance.GetChildObject(enemy);
                obj.transform.SetParent(transform);
                obj.SetDamage();
            }
        }
    }
}