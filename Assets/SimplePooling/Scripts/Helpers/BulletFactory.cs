using SimplePooling;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private ObjectPool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>();       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = bulletPool.Get();

            bulletPool.Release(bullet);
        }
    }
}
