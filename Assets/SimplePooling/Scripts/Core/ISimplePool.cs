using UnityEngine;

namespace SimplePooling
{
    public interface ISimplePool<T> where T : MonoBehaviour
    {
        T Get();
        void Release(T obj);
    }
}