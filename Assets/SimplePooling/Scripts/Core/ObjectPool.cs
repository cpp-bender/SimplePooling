using System.Collections.Generic;
using UnityEngine;

namespace SimplePooling
{
    public class ObjectPool<T>
    {
        private List<GameObject> objs;

        public ObjectPool()
        {
            objs = new List<GameObject>();
        }

        public GameObject Get()
        {
            //TODO: Complete
            return null;
        }


        public void Release(GameObject obj)
        {
            //TODO: Complete
        }
    }
}
