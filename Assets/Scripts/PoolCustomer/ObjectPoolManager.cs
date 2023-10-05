using System;
using System.Collections.Generic;
using UnityEngine;

namespace PoolCustomer
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance;

        private readonly Dictionary<ChildPoolObject, Dictionary<string, List<ChildPoolObject>>> _pool = new();

        private void Awake()
        {
            Instance = this;
        }

        public T GetChildObject<T>(T childPoolObject) where T : ChildPoolObject
        {
            while (true)
            {
                if (_pool.TryGetValue(childPoolObject, out var poolType))
                {
                    if (poolType.TryGetValue(childPoolObject.name, out var poolChild))
                        foreach (var child in poolChild)
                        {
                            if (!child.isActiveAndEnabled)
                            {
                                child.Active();
                                return child as T;
                            }
                        }
                }

                CreateOrAddToPool(childPoolObject, 1);
            }
        }

        private void CreateOrAddToPool<T>(T childPoolObject, int count) where T : ChildPoolObject
        {
            var key = childPoolObject.name;
            //init to base Pool
            if (!_pool.ContainsKey(childPoolObject))
            {
                var child = new Dictionary<string, List<ChildPoolObject>> { { key, new List<ChildPoolObject>() } };
                for (int i = 0; i < count; i++)
                {
                    var childObject = Instantiate(childPoolObject, transform);
                    childObject.name = key;
                    childObject.InActive();
                    child[key].Add(childObject);
                }

                _pool.Add(childPoolObject, child);
            }
            //init new child to pool string key
            else
            {
                var poolBase = _pool[childPoolObject];
                if (!poolBase.ContainsKey(key))
                {
                    var child = new Dictionary<string, List<ChildPoolObject>> { { key, new List<ChildPoolObject>() } };
                    for (int i = 0; i < count; i++)
                    {
                        var childObject = Instantiate(childPoolObject, transform);
                        childObject.name = key;
                        childObject.InActive();
                        child[key].Add(childObject);
                    }

                    _pool.Add(childPoolObject, child);
                }
                //init new child to pool string key
                else
                {
                    var child = poolBase[key];
                    var childObject = Instantiate(childPoolObject, transform);
                    childObject.name = key;
                    childObject.InActive();
                    child.Add(childObject);
                }
            }
        }

        public void ReturnChildToPool(ChildPoolObject childPoolObject)
        {
            childPoolObject.transform.SetParent(transform);
            childPoolObject.InActive();
        }
    }
}