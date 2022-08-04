using UnityEngine;

namespace SimplePooling
{
    public interface ISimplePool<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Returns a pool object from pool
        /// </summary>
        /// <returns></returns>
        T Get();
        /// <summary>
        /// Releases the given pool object to pool
        /// </summary>
        /// <param name="obj"></param>
        void Release(T obj);
    }
}