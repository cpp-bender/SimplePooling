using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }
}
