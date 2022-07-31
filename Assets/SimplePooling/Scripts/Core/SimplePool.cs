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
            Setup();

            Init();

            void Setup()
            {
                objs = new List<T>();

                poolData = simplePoolData;

                parent = new GameObject(simplePoolData.ParentName).transform;
            }

            void Init()
            {
                for (int i = 0; i < poolData.StartSize; i++)
                {
                    T obj = Object.Instantiate(poolData.Prefab).GetComponent<T>();

                    obj.name = poolData.SelfName;

                    obj.gameObject.SetActive(false);

                    obj.transform.SetParent(parent);

                    objs.Add(obj);
                }
            }
        }

        public T Get()
        {
            if (objs.Count == 0)
            {
                for (int i = 0; i < poolData.RefillSize; i++)
                {
                    T obj = Object.Instantiate(poolData.Prefab).GetComponent<T>();

                    obj.name = poolData.SelfName;

                    obj.gameObject.SetActive(false);

                    obj.transform.SetParent(parent);

                    objs.Add(obj);
                }
            }

            T lastObj = objs[objs.Count - 1];

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
