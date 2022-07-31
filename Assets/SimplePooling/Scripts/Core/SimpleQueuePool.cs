using System.Collections.Generic;
using UnityEngine;

namespace SimplePooling
{
    public class SimpleQueuePool<T> : BaseSimplePool<T>, ISimplePool<T> where T : MonoBehaviour
    {
        private Queue<T> objs;

        public SimpleQueuePool(SimplePoolData simplePoolData) : base(simplePoolData)
        {

        }

        protected override void Init(SimplePoolData simplePoolData)
        {
            objs = new Queue<T>();

            poolData = simplePoolData;

            parent = new GameObject(simplePoolData.ParentName).transform;

            for (int i = 0; i < poolData.StartSize; i++)
            {
                T obj = Object.Instantiate(poolData.Prefab).GetComponent<T>();

                obj.name = poolData.SelfName;

                obj.gameObject.SetActive(false);

                obj.transform.SetParent(parent);

                objs.Enqueue(obj);
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

                    objs.Enqueue(obj);
                }
            }

            T lastObj = objs.Peek();

            lastObj.gameObject.SetActive(true);

            lastObj.transform.SetParent(null);

            objs.Dequeue();

            return lastObj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);

            obj.transform.SetParent(parent);

            objs.Enqueue(obj);
        }
    }
}