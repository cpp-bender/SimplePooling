using System.Collections;
using SimplePooling;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public SimplePoolData poolData;

    private SimplePool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new SimplePool<Bullet>(poolData);

        bulletPool.Init();
    }

    private IEnumerator Routine()
    {
        var bullet = bulletPool.Get();

        yield return new WaitForSeconds(3f);

        bulletPool.Release(bullet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Routine());
        }
    }
}
