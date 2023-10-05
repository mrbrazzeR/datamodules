using UnityEngine;

namespace PoolCustomer
{
    public class ChildPoolObject:MonoBehaviour
    {
        public void Active()
        {
            gameObject.SetActive(true);
        }

        public void InActive()
        {
            gameObject.SetActive(false);
        }
    }
}