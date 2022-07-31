using UnityEngine;

namespace SimplePooling
{
    public abstract class BaseSimplePool<T> where T : MonoBehaviour
    {
        protected SimplePoolData poolData;
        protected Transform parent;

        public BaseSimplePool(SimplePoolData simplePoolData)
        {
            Init(simplePoolData);
        }

        protected abstract void Init(SimplePoolData simplePoolData);
    }
}
