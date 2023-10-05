using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PoolCustomer
{
    public class Enemy : ChildPoolObject
    {
        public float speed;
        private readonly List<Vector3> _waypoints = new();
        private int _current;
        private const float WRadius = 1;

        private void Start()
        {
            GetRandom();
        }

        public void SetDamage()
        {
            var random = Random.Range(0, 100);
            Debug.Log(random);
        }
        private void Update()
        {
            MoveBetweenWaypoints();
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ObjectPoolManager.Instance.ReturnChildToPool(this);
            }
        }

        private void GetRandom()
        {
            for (int i = 0; i < 30; i++)
            {
                var position = transform.position;
                _waypoints.Add(new Vector3(Random.Range(position.x, position.x + 3f),
                    Random.Range(position.y, position.y + 3f),
                    position.z));
            }
        }

        private void MoveBetweenWaypoints()
        {
            if (Vector3.Distance(_waypoints[_current], transform.position) < WRadius)
            {
                _current = Random.Range(0, _waypoints.Count);
                if (_current >= _waypoints.Count)
                {
                    _current = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_current], Time.deltaTime * speed);
        }
    }
}