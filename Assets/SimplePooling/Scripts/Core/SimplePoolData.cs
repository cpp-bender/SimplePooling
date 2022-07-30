using UnityEngine;

namespace SimplePooling
{
    [CreateAssetMenu(fileName = "Simple Pool", menuName = "Simple Pooling/Simple Pool")]
    public class SimplePoolData : ScriptableObject
    {
        [SerializeField] GameObject prefab;
        [SerializeField] int startSize;
        [SerializeField] int refillSize;
        [SerializeField] string parentName;
        [SerializeField] string selfName;

        public GameObject Prefab { get => prefab; }
        public int StartSize { get => startSize; }
        public int RefillSize { get => refillSize; }
        public string ParentName { get => parentName; }
        public string SelfName { get => selfName; }
    }
}