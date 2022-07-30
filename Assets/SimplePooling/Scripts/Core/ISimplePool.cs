using UnityEngine;

namespace SimplePooling
{
    public interface ISimplePool<T> where T : MonoBehaviour
    {
        //TODO: Use this interface to implement stack, queue and list types of SimplePool
        void Init();
        T Get();
        void Release(T obj);
    }
}