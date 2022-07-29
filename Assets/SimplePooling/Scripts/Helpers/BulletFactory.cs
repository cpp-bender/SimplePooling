using SimplePooling;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public SimplePoolData poolData;

    public GameObject tempGO;

    private SimplePool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new SimplePool<Bullet>(poolData);

        bulletPool.Init();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    var bullet = bulletPool.Get();

        //    bulletPool.Release();
        //}
    }
}
