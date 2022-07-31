using Object = UnityEngine.Object;
using UnityEngine;
using System;

namespace SimplePooling
{
    public class SimpleArrayPool<T> : BaseSimplePool<T>, ISimplePool<T> where T : MonoBehaviour
    {
        private T[] objs;
        private int iter;

        public SimpleArrayPool(SimplePoolData simplePoolData) : base(simplePoolData)
        {

        }

        protected override void Init(SimplePoolData simplePoolData)
        {
            iter = simplePoolData.StartSize - 1;

            objs = new T[simplePoolData.StartSize];

            poolData = simplePoolData;

            parent = new GameObject(simplePoolData.ParentName).transform;

            for (int i = 0; i < poolData.StartSize; i++)
            {
                T obj = Object.Instantiate(poolData.Prefab).GetComponent<T>();

                obj.name = poolData.SelfName;

                obj.gameObject.SetActive(false);

                obj.transform.SetParent(parent);

                objs[i] = obj;
            }
        }

        public T Get()
        {
            if (iter == -1)
            {
                Array.Resize(ref objs, objs.Length + poolData.RefillSize);

                iter = poolData.RefillSize - 1;

                for (int i = 0; i < poolData.RefillSize; i++)
                {
                    T obj = Object.Instantiate(poolData.Prefab).GetComponent<T>();

                    obj.name = poolData.SelfName;

                    obj.gameObject.SetActive(false);

                    obj.transform.SetParent(parent);

                    objs[i] = obj;
                }
            }

            T lastObj = objs[iter];

            lastObj.gameObject.SetActive(true);

            lastObj.transform.SetParent(null);

            objs[iter] = null;

            iter--;

            return lastObj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);

            obj.transform.SetParent(parent);

            iter++;

            objs[iter] = obj;
        }
    }
}