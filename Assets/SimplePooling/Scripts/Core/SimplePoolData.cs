using UnityEngine;

namespace SimplePooling
{
    [CreateAssetMenu(fileName = "Simple Pool", menuName = "Simple Pooling/Simple Pool")]
    public class SimplePoolData : ScriptableObject
    {
        [SerializeField, Space(2f)] GameObject prefab;
        [SerializeField, Space(2f)] int startSize;
        [SerializeField, Space(2f)] int refillSize;
        [SerializeField, Space(2f)] string parentName;
        [SerializeField, Space(2f)] string selfName;

        public GameObject Prefab { get => prefab; }
        public int StartSize { get => startSize; }
        public int RefillSize { get => refillSize; }
        public string ParentName { get => parentName; }
        public string SelfName { get => selfName; }
    }
}