using System.Collections.Generic;
using UnityEngine;

namespace SimplePooling
{
    public class SimplePool<T> where T : MonoBehaviour
    {
        private List<T> objs;
        private SimplePoolData poolData;

        public SimplePool(SimplePoolData simplePoolData)
        {
            objs = new List<T>();

            poolData = simplePoolData;
        }

        public void Init()
        {
            GameObject parent = new GameObject(poolData.ParentName);

            for (int i = 0; i < poolData.StartSize; i++)
            {
                T obj = Object.Instantiate(poolData.Prefab).GetComponent<T>();

                obj.name = poolData.SelfName + $" {i + 1}";

                obj.transform.SetParent(parent.transform);

                objs.Add(obj);
            }
        }

        public GameObject Get()
        {
            //TODO: Complete

            return null;
        }

        public void Release()
        {
            //TODO: Complete
        }
    }
}
