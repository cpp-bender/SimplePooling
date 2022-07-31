using System.Collections.Generic;
using UnityEngine;

namespace SimplePooling
{
    public class SimpleStackPool<T> : BaseSimplePool<T>, ISimplePool<T> where T : MonoBehaviour
    {
        private Stack<T> objs;

        public SimpleStackPool(SimplePoolData simplePoolData) : base(simplePoolData)
        {

        }

        protected override void Init(SimplePoolData simplePoolData)
        {
            objs = new Stack<T>();

            poolData = simplePoolData;

            parent = new GameObject(simplePoolData.ParentName).transform;

            for (int i = 0; i < poolData.StartSize; i++)
            {
                T obj = Object.Instantiate(poolData.Prefab).GetComponent<T>();

                obj.name = poolData.SelfName;

                obj.gameObject.SetActive(false);

                obj.transform.SetParent(parent);

                objs.Push(obj);
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

                    objs.Push(obj);
                }
            }

            T firstObj = objs.Peek();

            firstObj.gameObject.SetActive(true);

            firstObj.transform.SetParent(null);

            objs.Pop();

            return firstObj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);

            obj.transform.SetParent(parent);

            objs.Push(obj);
        }
    }
}