using System.Collections.Generic;
using UnityEngine;

namespace SimplePooling
{
    public class SimplePool<T> : ISimplePool<T> where T : MonoBehaviour
    {
        private List<T> objs;
        private SimplePoolData poolData;
        private Transform parent;

        public SimplePool(SimplePoolData simplePoolData)
        {
            objs = new List<T>();

            poolData = simplePoolData;

            parent = new GameObject(simplePoolData.ParentName).transform;
        }

        public void Init()
        {
            for (int i = 0; i < poolData.StartSize; i++)
            {
                T obj = Object.Instantiate(poolData.Prefab).GetComponent<T>();

                obj.name = poolData.SelfName + $" {i + 1}";

                obj.gameObject.SetActive(false);

                obj.transform.SetParent(parent);

                objs.Add(obj);
            }
        }

        public T Get()
        {
            T lastObj = objs[objs.Count - 1];

            if (lastObj == null)
            {
                //TODO: Handle here
            }

            lastObj.gameObject.SetActive(true);

            lastObj.transform.SetParent(null);

            objs.Remove(lastObj);

            return lastObj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);

            obj.transform.SetParent(parent);

            objs.Add(obj);
        }
    }
}
